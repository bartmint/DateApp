using DateApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateApp.Domain.Abstract
{
    public interface ITokenRepository
    {
        string CreateToken(AppUser user);
    }
}
