using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DateApp.Infrastructure.Migrations
{
    public partial class addmoredata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "publicId",
                table: "Photos",
                newName: "PublicId");

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "AppUserId", "IsMain", "PublicId", "Url" },
                values: new object[] { 12, 12, true, "5", "https://randomuser.me/api/portraits/women/54.jpg" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 10, 181, 236, 237, 185, 109, 39, 111, 197, 139, 101, 128, 46, 187, 6, 67, 252, 66, 87, 18, 17, 172, 31, 28, 45, 166, 87, 118, 128, 207, 21, 190, 251, 156, 58, 186, 24, 206, 211, 41, 182, 122, 74, 106, 19, 29, 109, 212, 170, 212, 216, 96, 14, 217, 27, 139, 54, 233, 241, 127, 63, 216, 109, 126 }, new byte[] { 164, 54, 194, 236, 177, 95, 244, 85, 192, 9, 204, 204, 110, 83, 169, 145, 146, 244, 75, 166, 161, 244, 189, 175, 12, 160, 252, 253, 29, 66, 41, 1, 82, 4, 173, 10, 127, 56, 123, 252, 10, 31, 39, 149, 243, 140, 183, 150, 33, 157, 210, 140, 102, 138, 31, 223, 142, 44, 34, 139, 200, 76, 190, 96, 234, 135, 20, 120, 51, 86, 70, 2, 38, 253, 145, 247, 252, 118, 235, 188, 239, 183, 137, 186, 181, 199, 185, 151, 249, 142, 191, 153, 155, 234, 242, 36, 230, 159, 234, 64, 43, 103, 167, 218, 204, 96, 43, 90, 89, 0, 81, 18, 174, 208, 65, 252, 93, 11, 164, 114, 173, 73, 220, 70, 166, 181, 252, 30 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Country", "Created", "DateOfBirth", "Gender", "Interests", "Introduction", "KnownAs", "LastActive", "LookingFor", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 13, "Greenbush", "Martinique", new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1956, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Sit sit incididunt proident velit.", "Sunt esse aliqua ullamco in incididunt consequat commodo. Nisi ad esse elit ipsum commodo fugiat est ad. Incididunt nostrud incididunt nostrud sit excepteur occaecat.\r\n", "Lisa", new DateTime(2020, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolor anim cupidatat occaecat aliquip et Lorem ut elit fugiat. Mollit eu pariatur est sunt. Minim fugiat sit do dolore eu elit ex do id sunt. Qui fugiat nostrud occaecat nisi est dolor qui fugiat laborum cillum. Occaecat consequat ex mollit commodo ad irure cillum nulla velit ex pariatur veniam cupidatat. Officia veniam officia non deserunt mollit.\r\n", new byte[] { 10, 181, 236, 237, 185, 109, 39, 111, 197, 139, 101, 128, 46, 187, 6, 67, 252, 66, 87, 18, 17, 172, 31, 28, 45, 166, 87, 118, 128, 207, 21, 190, 251, 156, 58, 186, 24, 206, 211, 41, 182, 122, 74, 106, 19, 29, 109, 212, 170, 212, 216, 96, 14, 217, 27, 139, 54, 233, 241, 127, 63, 216, 109, 126 }, new byte[] { 164, 54, 194, 236, 177, 95, 244, 85, 192, 9, 204, 204, 110, 83, 169, 145, 146, 244, 75, 166, 161, 244, 189, 175, 12, 160, 252, 253, 29, 66, 41, 1, 82, 4, 173, 10, 127, 56, 123, 252, 10, 31, 39, 149, 243, 140, 183, 150, 33, 157, 210, 140, 102, 138, 31, 223, 142, 44, 34, 139, 200, 76, 190, 96, 234, 135, 20, 120, 51, 86, 70, 2, 38, 253, 145, 247, 252, 118, 235, 188, 239, 183, 137, 186, 181, 199, 185, 151, 249, 142, 191, 153, 155, 234, 242, 36, 230, 159, 234, 64, 43, 103, 167, 218, 204, 96, 43, 90, 89, 0, 81, 18, 174, 208, 65, 252, 93, 11, 164, 114, 173, 73, 220, 70, 166, 181, 252, 30 }, "Martin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Country", "Created", "DateOfBirth", "Gender", "Interests", "Introduction", "KnownAs", "LastActive", "LookingFor", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 14, "Greenbush", "Martinique", new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1956, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Sit sit incididunt proident velit.", "Sunt esse aliqua ullamco in incididunt consequat commodo. Nisi ad esse elit ipsum commodo fugiat est ad. Incididunt nostrud incididunt nostrud sit excepteur occaecat.\r\n", "Lisa", new DateTime(2020, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolor anim cupidatat occaecat aliquip et Lorem ut elit fugiat. Mollit eu pariatur est sunt. Minim fugiat sit do dolore eu elit ex do id sunt. Qui fugiat nostrud occaecat nisi est dolor qui fugiat laborum cillum. Occaecat consequat ex mollit commodo ad irure cillum nulla velit ex pariatur veniam cupidatat. Officia veniam officia non deserunt mollit.\r\n", new byte[] { 10, 181, 236, 237, 185, 109, 39, 111, 197, 139, 101, 128, 46, 187, 6, 67, 252, 66, 87, 18, 17, 172, 31, 28, 45, 166, 87, 118, 128, 207, 21, 190, 251, 156, 58, 186, 24, 206, 211, 41, 182, 122, 74, 106, 19, 29, 109, 212, 170, 212, 216, 96, 14, 217, 27, 139, 54, 233, 241, 127, 63, 216, 109, 126 }, new byte[] { 164, 54, 194, 236, 177, 95, 244, 85, 192, 9, 204, 204, 110, 83, 169, 145, 146, 244, 75, 166, 161, 244, 189, 175, 12, 160, 252, 253, 29, 66, 41, 1, 82, 4, 173, 10, 127, 56, 123, 252, 10, 31, 39, 149, 243, 140, 183, 150, 33, 157, 210, 140, 102, 138, 31, 223, 142, 44, 34, 139, 200, 76, 190, 96, 234, 135, 20, 120, 51, 86, 70, 2, 38, 253, 145, 247, 252, 118, 235, 188, 239, 183, 137, 186, 181, 199, 185, 151, 249, 142, 191, 153, 155, 234, 242, 36, 230, 159, 234, 64, 43, 103, 167, 218, 204, 96, 43, 90, 89, 0, 81, 18, 174, 208, 65, 252, 93, 11, 164, 114, 173, 73, 220, 70, 166, 181, 252, 30 }, "Bartek" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "AppUserId", "IsMain", "PublicId", "Url" },
                values: new object[] { 13, 13, true, "5", "https://randomuser.me/api/portraits/women/50.jpg" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "AppUserId", "IsMain", "PublicId", "Url" },
                values: new object[] { 14, 14, true, "5", "https://randomuser.me/api/portraits/women/52.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.RenameColumn(
                name: "PublicId",
                table: "Photos",
                newName: "publicId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 232, 29, 40, 217, 98, 140, 175, 63, 241, 3, 188, 150, 99, 15, 227, 123, 27, 99, 86, 2, 76, 208, 51, 81, 55, 32, 196, 95, 215, 186, 97, 246, 66, 130, 59, 120, 44, 255, 117, 106, 97, 103, 26, 213, 48, 112, 30, 184, 118, 1, 34, 243, 61, 38, 51, 149, 211, 143, 137, 216, 135, 245, 249, 145 }, new byte[] { 171, 230, 209, 172, 228, 132, 252, 210, 62, 17, 7, 124, 85, 225, 207, 8, 54, 124, 65, 9, 235, 85, 138, 55, 24, 227, 22, 86, 185, 247, 223, 126, 254, 250, 244, 32, 187, 92, 36, 22, 157, 223, 18, 50, 93, 164, 202, 83, 154, 39, 17, 255, 205, 235, 143, 111, 18, 17, 231, 107, 252, 173, 232, 191, 219, 24, 126, 91, 197, 164, 90, 58, 158, 6, 112, 213, 77, 187, 142, 92, 16, 254, 178, 204, 197, 39, 94, 211, 38, 64, 30, 163, 218, 67, 237, 45, 59, 141, 145, 118, 186, 56, 152, 247, 8, 59, 204, 201, 200, 228, 91, 206, 14, 56, 150, 168, 104, 189, 165, 3, 154, 201, 41, 101, 231, 212, 244, 4 } });
        }
    }
}
