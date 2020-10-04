﻿// <auto-generated />
using System;
using DateApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DateApp.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201004122030_change password from seedData to lower case")]
    partial class changepasswordfromseedDatatolowercase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.8.20407.4");

            modelBuilder.Entity("DateApp.Domain.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("Interests")
                        .HasColumnType("TEXT");

                    b.Property<string>("Introduction")
                        .HasColumnType("TEXT");

                    b.Property<string>("KnownAs")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("TEXT");

                    b.Property<string>("LookingFor")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 12,
                            City = "Greenbush",
                            Country = "Martinique",
                            Created = new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1956, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "female",
                            Interests = "Sit sit incididunt proident velit.",
                            Introduction = "Sunt esse aliqua ullamco in incididunt consequat commodo. Nisi ad esse elit ipsum commodo fugiat est ad. Incididunt nostrud incididunt nostrud sit excepteur occaecat.\r\n",
                            KnownAs = "Lisa",
                            LastActive = new DateTime(2020, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookingFor = "Dolor anim cupidatat occaecat aliquip et Lorem ut elit fugiat. Mollit eu pariatur est sunt. Minim fugiat sit do dolore eu elit ex do id sunt. Qui fugiat nostrud occaecat nisi est dolor qui fugiat laborum cillum. Occaecat consequat ex mollit commodo ad irure cillum nulla velit ex pariatur veniam cupidatat. Officia veniam officia non deserunt mollit.\r\n",
                            PasswordHash = new byte[] { 130, 225, 165, 164, 46, 18, 38, 100, 92, 240, 203, 8, 114, 232, 169, 29, 251, 97, 138, 133, 152, 199, 128, 134, 197, 0, 31, 219, 117, 21, 103, 201, 86, 54, 238, 97, 47, 42, 85, 128, 239, 14, 145, 59, 219, 75, 122, 201, 237, 14, 203, 216, 252, 180, 215, 81, 44, 18, 120, 199, 104, 56, 114, 59 },
                            PasswordSalt = new byte[] { 224, 230, 77, 171, 211, 39, 133, 178, 180, 123, 53, 151, 246, 251, 46, 93, 91, 213, 98, 222, 158, 220, 209, 185, 77, 45, 46, 133, 255, 176, 231, 74, 16, 16, 143, 209, 89, 161, 209, 153, 168, 127, 58, 193, 24, 101, 187, 3, 95, 94, 169, 108, 143, 10, 148, 243, 26, 111, 57, 177, 196, 123, 101, 252, 8, 138, 67, 222, 15, 135, 185, 34, 45, 183, 105, 92, 61, 139, 136, 95, 220, 157, 143, 66, 231, 52, 60, 33, 144, 31, 44, 92, 61, 10, 252, 81, 58, 188, 126, 83, 95, 18, 169, 10, 232, 71, 195, 137, 158, 171, 54, 79, 24, 200, 225, 11, 91, 1, 232, 1, 195, 177, 136, 76, 41, 59, 157, 67 },
                            Username = "lisa"
                        },
                        new
                        {
                            Id = 13,
                            City = "Greenbush",
                            Country = "Martinique",
                            Created = new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1956, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Interests = "Sit sit incididunt proident velit.",
                            Introduction = "Sunt esse aliqua ullamco in incididunt consequat commodo. Nisi ad esse elit ipsum commodo fugiat est ad. Incididunt nostrud incididunt nostrud sit excepteur occaecat.\r\n",
                            KnownAs = "martinoo",
                            LastActive = new DateTime(2020, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookingFor = "Dolor anim cupidatat occaecat aliquip et Lorem ut elit fugiat. Mollit eu pariatur est sunt. Minim fugiat sit do dolore eu elit ex do id sunt. Qui fugiat nostrud occaecat nisi est dolor qui fugiat laborum cillum. Occaecat consequat ex mollit commodo ad irure cillum nulla velit ex pariatur veniam cupidatat. Officia veniam officia non deserunt mollit.\r\n",
                            PasswordHash = new byte[] { 130, 225, 165, 164, 46, 18, 38, 100, 92, 240, 203, 8, 114, 232, 169, 29, 251, 97, 138, 133, 152, 199, 128, 134, 197, 0, 31, 219, 117, 21, 103, 201, 86, 54, 238, 97, 47, 42, 85, 128, 239, 14, 145, 59, 219, 75, 122, 201, 237, 14, 203, 216, 252, 180, 215, 81, 44, 18, 120, 199, 104, 56, 114, 59 },
                            PasswordSalt = new byte[] { 224, 230, 77, 171, 211, 39, 133, 178, 180, 123, 53, 151, 246, 251, 46, 93, 91, 213, 98, 222, 158, 220, 209, 185, 77, 45, 46, 133, 255, 176, 231, 74, 16, 16, 143, 209, 89, 161, 209, 153, 168, 127, 58, 193, 24, 101, 187, 3, 95, 94, 169, 108, 143, 10, 148, 243, 26, 111, 57, 177, 196, 123, 101, 252, 8, 138, 67, 222, 15, 135, 185, 34, 45, 183, 105, 92, 61, 139, 136, 95, 220, 157, 143, 66, 231, 52, 60, 33, 144, 31, 44, 92, 61, 10, 252, 81, 58, 188, 126, 83, 95, 18, 169, 10, 232, 71, 195, 137, 158, 171, 54, 79, 24, 200, 225, 11, 91, 1, 232, 1, 195, 177, 136, 76, 41, 59, 157, 67 },
                            Username = "martin"
                        },
                        new
                        {
                            Id = 14,
                            City = "Greenbush",
                            Country = "Martinique",
                            Created = new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1956, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "male",
                            Interests = "Sit sit incididunt proident velit.",
                            Introduction = "Sunt esse aliqua ullamco in incididunt consequat commodo. Nisi ad esse elit ipsum commodo fugiat est ad. Incididunt nostrud incididunt nostrud sit excepteur occaecat.\r\n",
                            KnownAs = "barteko",
                            LastActive = new DateTime(2020, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LookingFor = "Dolor anim cupidatat occaecat aliquip et Lorem ut elit fugiat. Mollit eu pariatur est sunt. Minim fugiat sit do dolore eu elit ex do id sunt. Qui fugiat nostrud occaecat nisi est dolor qui fugiat laborum cillum. Occaecat consequat ex mollit commodo ad irure cillum nulla velit ex pariatur veniam cupidatat. Officia veniam officia non deserunt mollit.\r\n",
                            PasswordHash = new byte[] { 130, 225, 165, 164, 46, 18, 38, 100, 92, 240, 203, 8, 114, 232, 169, 29, 251, 97, 138, 133, 152, 199, 128, 134, 197, 0, 31, 219, 117, 21, 103, 201, 86, 54, 238, 97, 47, 42, 85, 128, 239, 14, 145, 59, 219, 75, 122, 201, 237, 14, 203, 216, 252, 180, 215, 81, 44, 18, 120, 199, 104, 56, 114, 59 },
                            PasswordSalt = new byte[] { 224, 230, 77, 171, 211, 39, 133, 178, 180, 123, 53, 151, 246, 251, 46, 93, 91, 213, 98, 222, 158, 220, 209, 185, 77, 45, 46, 133, 255, 176, 231, 74, 16, 16, 143, 209, 89, 161, 209, 153, 168, 127, 58, 193, 24, 101, 187, 3, 95, 94, 169, 108, 143, 10, 148, 243, 26, 111, 57, 177, 196, 123, 101, 252, 8, 138, 67, 222, 15, 135, 185, 34, 45, 183, 105, 92, 61, 139, 136, 95, 220, 157, 143, 66, 231, 52, 60, 33, 144, 31, 44, 92, 61, 10, 252, 81, 58, 188, 126, 83, 95, 18, 169, 10, 232, 71, 195, 137, 158, 171, 54, 79, 24, 200, 225, 11, 91, 1, 232, 1, 195, 177, 136, 76, 41, 59, 157, 67 },
                            Username = "bartek"
                        });
                });

            modelBuilder.Entity("DateApp.Domain.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            Id = 12,
                            AppUserId = 12,
                            IsMain = true,
                            PublicId = "5",
                            Url = "https://randomuser.me/api/portraits/women/54.jpg"
                        },
                        new
                        {
                            Id = 13,
                            AppUserId = 13,
                            IsMain = true,
                            PublicId = "5",
                            Url = "https://randomuser.me/api/portraits/women/50.jpg"
                        },
                        new
                        {
                            Id = 14,
                            AppUserId = 14,
                            IsMain = true,
                            PublicId = "5",
                            Url = "https://randomuser.me/api/portraits/women/52.jpg"
                        });
                });

            modelBuilder.Entity("DateApp.Domain.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("DateApp.Domain.Models.Photo", b =>
                {
                    b.HasOne("DateApp.Domain.Models.AppUser", "AppUser")
                        .WithMany("Photos")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
