using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaCuentas.Identity.Migrations
{
    /// <inheritdoc />
    public partial class UserAdminDefault3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "587032dc-2148-4f00-a347-2b04c2a583d7");

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "c9f1c4f9-45b8-440e-ad50-494d3f55ddd5");

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aebabbc3-e1bc-4037-ae84-ec94428e0b06", null, "Admin", "ADMIN" },
                    { "bb3dd25f-8a10-4255-9339-98a6000711d3", null, "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AccountUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Document", "DocumentType", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "01050660-1857-4a26-ab30-1abef1e699e0", 0, "Calle Admin", "867a676e-94ff-4eaf-b193-2d665e98793d", "ApplicationIdentity", "123456789", "CC", "admin@system.com", false, "Admin", false, null, "ADMIN@SYSTEM.COM", "ADMIN@SYSTEM.COM", "AQAAAAIAAYagAAAAEL5+V1Mu7Se4K4tOhd2LJJrbTqbVa3Xot2NdR1T45pUS2KEmoOJ7tWHgNiMTtfuQag==", null, false, "E572914D-04BB-49CC-9708-5E1264781BF0", false, "admin@system.com" });

            migrationBuilder.InsertData(
                table: "AccountUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aebabbc3-e1bc-4037-ae84-ec94428e0b06", "01050660-1857-4a26-ab30-1abef1e699e0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "bb3dd25f-8a10-4255-9339-98a6000711d3");

            migrationBuilder.DeleteData(
                table: "AccountUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aebabbc3-e1bc-4037-ae84-ec94428e0b06", "01050660-1857-4a26-ab30-1abef1e699e0" });

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "aebabbc3-e1bc-4037-ae84-ec94428e0b06");

            migrationBuilder.DeleteData(
                table: "AccountUsers",
                keyColumn: "Id",
                keyValue: "01050660-1857-4a26-ab30-1abef1e699e0");

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "587032dc-2148-4f00-a347-2b04c2a583d7", null, "Usuario", "USUARIO" },
                    { "c9f1c4f9-45b8-440e-ad50-494d3f55ddd5", null, "Admin", "ADMIN" }
                });
        }
    }
}
