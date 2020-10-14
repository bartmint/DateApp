using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DateApp.Infrastructure.Migrations
{
    public partial class Messageentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SenderId = table.Column<int>(type: "INTEGER", nullable: false),
                    SenderUsername = table.Column<string>(type: "TEXT", nullable: true),
                    RecipientId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipientUsername = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    DateRead = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Messagesent = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SenderDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    RecipientDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 115, 245, 63, 62, 206, 23, 126, 108, 240, 65, 12, 63, 224, 20, 80, 205, 75, 141, 187, 17, 123, 229, 71, 166, 218, 38, 112, 190, 237, 174, 208, 45, 106, 93, 161, 134, 38, 249, 215, 46, 159, 8, 34, 199, 150, 20, 164, 76, 127, 199, 52, 200, 42, 199, 120, 61, 238, 83, 200, 39, 190, 208, 191, 210 }, new byte[] { 45, 100, 147, 213, 33, 71, 59, 5, 230, 135, 99, 109, 111, 69, 170, 105, 62, 237, 253, 245, 13, 95, 51, 29, 186, 82, 177, 246, 110, 173, 85, 102, 70, 64, 220, 49, 22, 168, 65, 19, 123, 244, 206, 17, 63, 216, 220, 198, 129, 115, 76, 62, 151, 100, 63, 223, 191, 66, 231, 160, 217, 45, 144, 242, 11, 122, 26, 27, 213, 100, 254, 83, 11, 208, 65, 77, 130, 236, 241, 6, 168, 100, 198, 75, 63, 207, 105, 169, 138, 22, 167, 210, 26, 44, 48, 201, 240, 128, 208, 188, 41, 248, 1, 64, 41, 89, 251, 128, 227, 74, 53, 100, 193, 200, 118, 152, 22, 84, 152, 59, 98, 195, 76, 59, 69, 32, 84, 214 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 115, 245, 63, 62, 206, 23, 126, 108, 240, 65, 12, 63, 224, 20, 80, 205, 75, 141, 187, 17, 123, 229, 71, 166, 218, 38, 112, 190, 237, 174, 208, 45, 106, 93, 161, 134, 38, 249, 215, 46, 159, 8, 34, 199, 150, 20, 164, 76, 127, 199, 52, 200, 42, 199, 120, 61, 238, 83, 200, 39, 190, 208, 191, 210 }, new byte[] { 45, 100, 147, 213, 33, 71, 59, 5, 230, 135, 99, 109, 111, 69, 170, 105, 62, 237, 253, 245, 13, 95, 51, 29, 186, 82, 177, 246, 110, 173, 85, 102, 70, 64, 220, 49, 22, 168, 65, 19, 123, 244, 206, 17, 63, 216, 220, 198, 129, 115, 76, 62, 151, 100, 63, 223, 191, 66, 231, 160, 217, 45, 144, 242, 11, 122, 26, 27, 213, 100, 254, 83, 11, 208, 65, 77, 130, 236, 241, 6, 168, 100, 198, 75, 63, 207, 105, 169, 138, 22, 167, 210, 26, 44, 48, 201, 240, 128, 208, 188, 41, 248, 1, 64, 41, 89, 251, 128, 227, 74, 53, 100, 193, 200, 118, 152, 22, 84, 152, 59, 98, 195, 76, 59, 69, 32, 84, 214 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 115, 245, 63, 62, 206, 23, 126, 108, 240, 65, 12, 63, 224, 20, 80, 205, 75, 141, 187, 17, 123, 229, 71, 166, 218, 38, 112, 190, 237, 174, 208, 45, 106, 93, 161, 134, 38, 249, 215, 46, 159, 8, 34, 199, 150, 20, 164, 76, 127, 199, 52, 200, 42, 199, 120, 61, 238, 83, 200, 39, 190, 208, 191, 210 }, new byte[] { 45, 100, 147, 213, 33, 71, 59, 5, 230, 135, 99, 109, 111, 69, 170, 105, 62, 237, 253, 245, 13, 95, 51, 29, 186, 82, 177, 246, 110, 173, 85, 102, 70, 64, 220, 49, 22, 168, 65, 19, 123, 244, 206, 17, 63, 216, 220, 198, 129, 115, 76, 62, 151, 100, 63, 223, 191, 66, 231, 160, 217, 45, 144, 242, 11, 122, 26, 27, 213, 100, 254, 83, 11, 208, 65, 77, 130, 236, 241, 6, 168, 100, 198, 75, 63, 207, 105, 169, 138, 22, 167, 210, 26, 44, 48, 201, 240, 128, 208, 188, 41, 248, 1, 64, 41, 89, 251, 128, 227, 74, 53, 100, 193, 200, 118, 152, 22, 84, 152, 59, 98, 195, 76, 59, 69, 32, 84, 214 } });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 241, 244, 79, 51, 183, 6, 46, 160, 99, 206, 166, 109, 184, 163, 146, 196, 217, 9, 65, 195, 85, 172, 21, 154, 13, 247, 86, 178, 177, 5, 153, 41, 150, 69, 124, 254, 143, 122, 187, 11, 178, 80, 151, 136, 35, 110, 232, 43, 27, 94, 161, 131, 223, 93, 115, 196, 183, 124, 110, 50, 95, 111, 230, 48 }, new byte[] { 94, 223, 56, 100, 161, 248, 184, 140, 175, 74, 6, 80, 199, 122, 142, 52, 24, 120, 201, 57, 208, 136, 246, 3, 150, 66, 135, 206, 243, 102, 194, 165, 157, 229, 96, 255, 10, 63, 82, 156, 2, 30, 91, 55, 94, 44, 29, 69, 201, 77, 29, 216, 65, 206, 67, 184, 156, 250, 249, 252, 220, 238, 85, 21, 79, 90, 147, 208, 19, 46, 192, 88, 183, 204, 217, 230, 48, 205, 138, 79, 39, 67, 248, 179, 151, 220, 180, 117, 89, 128, 144, 56, 53, 203, 140, 46, 75, 144, 157, 168, 24, 129, 125, 215, 104, 188, 199, 213, 112, 152, 200, 252, 217, 254, 0, 204, 76, 179, 199, 244, 104, 140, 154, 152, 209, 183, 169, 200 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 241, 244, 79, 51, 183, 6, 46, 160, 99, 206, 166, 109, 184, 163, 146, 196, 217, 9, 65, 195, 85, 172, 21, 154, 13, 247, 86, 178, 177, 5, 153, 41, 150, 69, 124, 254, 143, 122, 187, 11, 178, 80, 151, 136, 35, 110, 232, 43, 27, 94, 161, 131, 223, 93, 115, 196, 183, 124, 110, 50, 95, 111, 230, 48 }, new byte[] { 94, 223, 56, 100, 161, 248, 184, 140, 175, 74, 6, 80, 199, 122, 142, 52, 24, 120, 201, 57, 208, 136, 246, 3, 150, 66, 135, 206, 243, 102, 194, 165, 157, 229, 96, 255, 10, 63, 82, 156, 2, 30, 91, 55, 94, 44, 29, 69, 201, 77, 29, 216, 65, 206, 67, 184, 156, 250, 249, 252, 220, 238, 85, 21, 79, 90, 147, 208, 19, 46, 192, 88, 183, 204, 217, 230, 48, 205, 138, 79, 39, 67, 248, 179, 151, 220, 180, 117, 89, 128, 144, 56, 53, 203, 140, 46, 75, 144, 157, 168, 24, 129, 125, 215, 104, 188, 199, 213, 112, 152, 200, 252, 217, 254, 0, 204, 76, 179, 199, 244, 104, 140, 154, 152, 209, 183, 169, 200 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 241, 244, 79, 51, 183, 6, 46, 160, 99, 206, 166, 109, 184, 163, 146, 196, 217, 9, 65, 195, 85, 172, 21, 154, 13, 247, 86, 178, 177, 5, 153, 41, 150, 69, 124, 254, 143, 122, 187, 11, 178, 80, 151, 136, 35, 110, 232, 43, 27, 94, 161, 131, 223, 93, 115, 196, 183, 124, 110, 50, 95, 111, 230, 48 }, new byte[] { 94, 223, 56, 100, 161, 248, 184, 140, 175, 74, 6, 80, 199, 122, 142, 52, 24, 120, 201, 57, 208, 136, 246, 3, 150, 66, 135, 206, 243, 102, 194, 165, 157, 229, 96, 255, 10, 63, 82, 156, 2, 30, 91, 55, 94, 44, 29, 69, 201, 77, 29, 216, 65, 206, 67, 184, 156, 250, 249, 252, 220, 238, 85, 21, 79, 90, 147, 208, 19, 46, 192, 88, 183, 204, 217, 230, 48, 205, 138, 79, 39, 67, 248, 179, 151, 220, 180, 117, 89, 128, 144, 56, 53, 203, 140, 46, 75, 144, 157, 168, 24, 129, 125, 215, 104, 188, 199, 213, 112, 152, 200, 252, 217, 254, 0, 204, 76, 179, 199, 244, 104, 140, 154, 152, 209, 183, 169, 200 } });
        }
    }
}
