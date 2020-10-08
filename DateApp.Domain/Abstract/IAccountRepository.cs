using DateApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.Domain.Abstract
{
    public interface IAccountRepository
    {
        Task<AppUser> Register(string username, string password,
            string KnownAs, string Gender, DateTime DateOfBirth, string City, string Country);
        Task<AppUser> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
