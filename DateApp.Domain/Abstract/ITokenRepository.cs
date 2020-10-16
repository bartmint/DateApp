using DateApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.Domain.Abstract
{
    public interface ITokenRepository
    {
        Task<string> CreateToken(AppUser user);
    }
}
