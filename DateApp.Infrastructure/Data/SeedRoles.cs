using DateApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.Infrastructure.Data
{
    public static class SeedR {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole { Id = 1, Name = "Admin", NormalizedName="ADMIN" },
                new AppRole { Id = 2, Name = "Moderator", NormalizedName = "MODERATOR" },
                new AppRole { Id = 3, Name = "Member", NormalizedName = "MEMBER" }
            );
        }
    }
    public static class AddToRole
    {
        public static async Task<IServiceProvider> AddAdmin(this IServiceProvider _service)
        {
            var userManager = _service.GetRequiredService<UserManager<AppUser>>();

            var admin = new AppUser()
            {
                UserName = "admin"
            };
            await userManager.CreateAsync(admin, "Capek132@");
            await userManager.AddToRoleAsync(admin, "Admin");

            return _service;
        }
    }
}
