using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DateApp.Infrastructure.Migrations
{
    public partial class addsomedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KnowAs",
                table: "Users",
                newName: "KnownAs");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Country", "Created", "DateOfBirth", "Gender", "Interests", "Introduction", "KnownAs", "LastActive", "LookingFor", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 12, "Greenbush", "Martinique", new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1956, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "female", "Sit sit incididunt proident velit.", "Sunt esse aliqua ullamco in incididunt consequat commodo. Nisi ad esse elit ipsum commodo fugiat est ad. Incididunt nostrud incididunt nostrud sit excepteur occaecat.\r\n", "Lisa", new DateTime(2020, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolor anim cupidatat occaecat aliquip et Lorem ut elit fugiat. Mollit eu pariatur est sunt. Minim fugiat sit do dolore eu elit ex do id sunt. Qui fugiat nostrud occaecat nisi est dolor qui fugiat laborum cillum. Occaecat consequat ex mollit commodo ad irure cillum nulla velit ex pariatur veniam cupidatat. Officia veniam officia non deserunt mollit.\r\n", new byte[] { 232, 29, 40, 217, 98, 140, 175, 63, 241, 3, 188, 150, 99, 15, 227, 123, 27, 99, 86, 2, 76, 208, 51, 81, 55, 32, 196, 95, 215, 186, 97, 246, 66, 130, 59, 120, 44, 255, 117, 106, 97, 103, 26, 213, 48, 112, 30, 184, 118, 1, 34, 243, 61, 38, 51, 149, 211, 143, 137, 216, 135, 245, 249, 145 }, new byte[] { 171, 230, 209, 172, 228, 132, 252, 210, 62, 17, 7, 124, 85, 225, 207, 8, 54, 124, 65, 9, 235, 85, 138, 55, 24, 227, 22, 86, 185, 247, 223, 126, 254, 250, 244, 32, 187, 92, 36, 22, 157, 223, 18, 50, 93, 164, 202, 83, 154, 39, 17, 255, 205, 235, 143, 111, 18, 17, 231, 107, 252, 173, 232, 191, 219, 24, 126, 91, 197, 164, 90, 58, 158, 6, 112, 213, 77, 187, 142, 92, 16, 254, 178, 204, 197, 39, 94, 211, 38, 64, 30, 163, 218, 67, 237, 45, 59, 141, 145, 118, 186, 56, 152, 247, 8, 59, 204, 201, 200, 228, 91, 206, 14, 56, 150, 168, 104, 189, 165, 3, 154, 201, 41, 101, 231, 212, 244, 4 }, "Lisa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.RenameColumn(
                name: "KnownAs",
                table: "Users",
                newName: "KnowAs");
        }
    }
}
