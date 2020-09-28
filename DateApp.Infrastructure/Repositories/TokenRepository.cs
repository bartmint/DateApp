using DateApp.Domain.Abstract;
using DateApp.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DateApp.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly SymmetricSecurityKey _key;

        public TokenRepository(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>//rozszczenia
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Username)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);//poswiadczenie
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
