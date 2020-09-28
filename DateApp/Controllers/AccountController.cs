using DateApp.Domain.Abstract;
using DateApp.Domain.Models;
using DateApp.UI.Models.DTO;
using DateApp.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.UI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountRepository _authRepository;
        private readonly IConfiguration _configuration;
        private readonly ITokenRepository _tokenRepository;

        public AccountController(IAccountRepository authRepository, IConfiguration configuration, ITokenRepository tokenRepository)
        {
            _authRepository = authRepository;
            _configuration = configuration;
            _tokenRepository = tokenRepository;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(UserForRegisterDtO userForRegister)
        {
            userForRegister.Username = userForRegister.Username.ToLower();
            if (await _authRepository.UserExists(userForRegister.Username))
                return BadRequest("User already exists");

            var userDTO = new UserDTO
            {
                Username = userForRegister.Username,
                Token=_tokenRepository.CreateToken(new AppUser { Username=userForRegister.Username})
            };
            await _authRepository.Register(userDTO.Username, userForRegister.Password);

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
                Token = _tokenRepository.CreateToken(new AppUser { Username = userForLogin.Username })
            };
            await _authRepository.Login(userDTO.Username, userForLogin.Password);

            return userDTO;




        }

    }
}
