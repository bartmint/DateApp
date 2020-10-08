using AutoMapper;
using DateApp.Domain.Abstract;
using DateApp.Domain.Models;
using DateApp.UI.Models.DTO;
using DateApp.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        public AccountController(IAccountRepository authRepository,
            IConfiguration configuration, ITokenRepository tokenRepository, IPhotoGet photoGet, IMapper automapper)
        {
            _automapper = automapper;
            _authRepository = authRepository;
            _configuration = configuration;
            _tokenRepository = tokenRepository;
            _photoGet = photoGet;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(UserForRegisterDtO userForRegister)
        {
            userForRegister.Username = userForRegister.Username.ToLower();
            if (await _authRepository.UserExists(userForRegister.Username))
                return BadRequest("User already exists");
            var user = _automapper.Map<AppUser>(userForRegister);

            await _authRepository.Register(userForRegister.Username, userForRegister.Password,
            userForRegister.KnownAs, userForRegister.Gender, userForRegister.DateOfBirth, userForRegister.City, userForRegister.Country);

            var userDTO = new UserDTO
            {
                Username = userForRegister.Username,
                Token = _tokenRepository.CreateToken(new AppUser { Username = userForRegister.Username }),
                KnownAs = user.KnownAs
            };

            return userDTO;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(UserForLoginDTO userForLogin)
        {
            var userFromRepo = await _authRepository.Login(userForLogin.Username.ToLower(), userForLogin.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var userDTO = new UserDTO
            {
                Username = userForLogin.Username,
                Token = _tokenRepository.CreateToken(new AppUser { Username = userForLogin.Username }),
                PhotoUrl= await _photoGet.GetPhoto(userFromRepo.Id)
            };
            await _authRepository.Login(userDTO.Username, userForLogin.Password);

            return userDTO;
        }
       

    }
}
