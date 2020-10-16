using AutoMapper;
using DateApp.Domain.Abstract;
using DateApp.Domain.Models;
using DateApp.UI.Models.DTO;
using DateApp.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.UI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IMapper _automapper;
        private readonly IAccountRepository _authRepository;
        private readonly IConfiguration _configuration;
        private readonly ITokenRepository _tokenRepository;
        private readonly IPhotoGet _photoGet;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IAccountRepository authRepository,
            IConfiguration configuration, ITokenRepository tokenRepository, IPhotoGet photoGet, IMapper automapper,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _automapper = automapper;
            _authRepository = authRepository;
            _configuration = configuration;
            _tokenRepository = tokenRepository;
            _photoGet = photoGet;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(UserForRegisterDtO userForRegister)
        {
            userForRegister.Username = userForRegister.Username.ToLower();
            if (await _authRepository.UserExists(userForRegister.Username))
                return BadRequest("User already exists");
            var user = _automapper.Map<AppUser>(userForRegister);

            user.UserName = user.UserName.ToLower();
           // await _userManager.AddToRolesAsync(user, new[] { "Member" });
                
            var result =await _userManager.CreateAsync(user, userForRegister.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            //var registeredUser=await _authRepository.Register(userForRegister.Username, userForRegister.Password,
            //userForRegister.KnownAs, userForRegister.Gender, userForRegister.DateOfBirth, userForRegister.City, userForRegister.Country);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            var userDTO = new UserDTO
            {
                Username = userForRegister.Username,
                Token =await _tokenRepository.CreateToken(user), //za duzy obiekt do przesylania
                KnownAs = user.KnownAs,
                Gender=user.Gender
            };

            return userDTO;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(UserForLoginDTO userForLogin)
        {
            var userFromRepo = await _userManager.Users.Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == userForLogin.Username.ToLower());

            if (userFromRepo == null)
                return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(userFromRepo, userForLogin.Password, false);

            if (!result.Succeeded) return Unauthorized();

            var userDTO = new UserDTO
            {
                Username = userForLogin.Username,
                Token =await _tokenRepository.CreateToken(userFromRepo),
                PhotoUrl= await _photoGet.GetPhoto(userFromRepo.Id),
                Gender=userFromRepo.Gender,
                KnownAs=userFromRepo.KnownAs
            };
            await _authRepository.Login(userDTO.Username, userForLogin.Password);

            return userDTO;
        }
       

    }
}
