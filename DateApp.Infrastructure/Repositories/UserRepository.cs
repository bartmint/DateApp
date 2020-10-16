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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _ctx;

        public UserRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _ctx.Users.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _ctx.Users
                .Include(p=>p.Photos)
                .FirstOrDefaultAsync(i => i.UserName == username);
        }
        public IQueryable<AppUser> GetUsersAsync()
        {
            return _ctx.Users;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _ctx.SaveChangesAsync() > 0; //jesli cos zostanie zmienione to zwraca wartosc wieksza niz 0

        }

        public void Update(AppUser user)
        {
            _ctx.Entry(user).State = EntityState.Modified;
        }
    }
}
