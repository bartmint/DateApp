using DateApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DateApp.Infrastructure.Data
{
    public static class SeedU
    {
        public static void SeedUsers(this ModelBuilder modelbuilder)
        {
            var hmac = new HMACSHA512();
            modelbuilder.Entity<AppUser>().HasData
                (
                new AppUser
                {
                    Id = 12,
                    UserName = "lisa",
                    Gender = "female",
                    DateOfBirth = Convert.ToDateTime("1956-07-22"),
                    KnownAs = "Lisa",
                    Created = Convert.ToDateTime("2020-06-24"),
                    LastActive = Convert.ToDateTime("2020-06-21"),
                    Introduction = "Sunt esse aliqua ullamco in incididunt consequat commodo. Nisi ad esse elit ipsum commodo fugiat est ad. Incididunt nostrud incididunt nostrud sit excepteur occaecat.\r\n",
                    LookingFor = "Dolor anim cupidatat occaecat aliquip et Lorem ut elit fugiat. Mollit eu pariatur est sunt. Minim fugiat sit do dolore eu elit ex do id sunt. Qui fugiat nostrud occaecat nisi est dolor qui fugiat laborum cillum. Occaecat consequat ex mollit commodo ad irure cillum nulla velit ex pariatur veniam cupidatat. Officia veniam officia non deserunt mollit.\r\n",
                    Interests = "Sit sit incididunt proident velit.",
                    City = "Greenbush",
                    Country = "Martinique",
                },
                new AppUser
                {
                    Id = 13,
                    UserName = "Admin",
                    Gender = "Male",
                    DateOfBirth = Convert.ToDateTime("1956-07-22"),
                    KnownAs = "martinoo",
                    Created = Convert.ToDateTime("2020-06-24"),
                    LastActive = Convert.ToDateTime("2020-06-21"),
                    Introduction = "Sunt esse aliqua ullamco in incididunt consequat commodo. Nisi ad esse elit ipsum commodo fugiat est ad. Incididunt nostrud incididunt nostrud sit excepteur occaecat.\r\n",
                    LookingFor = "Dolor anim cupidatat occaecat aliquip et Lorem ut elit fugiat. Mollit eu pariatur est sunt. Minim fugiat sit do dolore eu elit ex do id sunt. Qui fugiat nostrud occaecat nisi est dolor qui fugiat laborum cillum. Occaecat consequat ex mollit commodo ad irure cillum nulla velit ex pariatur veniam cupidatat. Officia veniam officia non deserunt mollit.\r\n",
                    Interests = "Sit sit incididunt proident velit.",
                    City = "Greenbush",
                    Country = "Martinique",
                    PasswordHash="Admin1"
                    
                }, new AppUser
                {
                    Id = 14,
                    UserName = "bartek",
                    Gender = "male",
                    DateOfBirth = Convert.ToDateTime("1956-07-22"),
                    KnownAs = "barteko",
                    Created = Convert.ToDateTime("2020-06-24"),
                    LastActive = Convert.ToDateTime("2020-06-21"),
                    Introduction = "Sunt esse aliqua ullamco in incididunt consequat commodo. Nisi ad esse elit ipsum commodo fugiat est ad. Incididunt nostrud incididunt nostrud sit excepteur occaecat.\r\n",
                    LookingFor = "Dolor anim cupidatat occaecat aliquip et Lorem ut elit fugiat. Mollit eu pariatur est sunt. Minim fugiat sit do dolore eu elit ex do id sunt. Qui fugiat nostrud occaecat nisi est dolor qui fugiat laborum cillum. Occaecat consequat ex mollit commodo ad irure cillum nulla velit ex pariatur veniam cupidatat. Officia veniam officia non deserunt mollit.\r\n",
                    Interests = "Sit sit incididunt proident velit.",
                    City = "Greenbush",
                    Country = "Martinique",
                }
                ) ;
            modelbuilder.Entity<Photo>().HasData(
                new Photo { Url = "https://randomuser.me/api/portraits/women/54.jpg", IsMain = true, AppUserId=12, Id=12, PublicId="5" },
                new Photo { Url = "https://randomuser.me/api/portraits/women/50.jpg", IsMain = true, AppUserId=13, Id=13, PublicId = "5" },
                new Photo { Url = "https://randomuser.me/api/portraits/women/52.jpg", IsMain = true, AppUserId=14, Id=14, PublicId = "5" }
                );
            
        }
    }
}
