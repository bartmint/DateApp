using DateApp.Domain.Abstract;
using DateApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _ctx;

        public AccountRepository(AppDbContext appDbContext)
        {
            _ctx = appDbContext;
        }
        public async Task<AppUser> Login(string username, string password)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user is null) 
                return null;

            //if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //    return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for(int i=0; i<computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<AppUser> Register(string username, string password,
            string knownAs, string gender, DateTime dateOfBirth, string city, string country)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new AppUser
            {
                UserName = username,
                KnownAs=knownAs,
                Gender=gender,
                DateOfBirth=dateOfBirth,
                City=city,
                Country=country
            };

            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _ctx.Users.AnyAsync(u => u.UserName == username))
                return true;

            return false;
        }
    }
}
