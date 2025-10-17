using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaCuentas.Identity.Migrations
{
    /// <inheritdoc />
    public partial class UserAdminDefault2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "61684a0e-8a1e-4530-b80b-f731439a5613");

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "91b26e95-b052-4198-b482-c365c17762a4");

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95becdc5-4823-42fa-b8d6-3342b471be7a", null, "Usuario", "USUARIO" },
                    { "d61700b6-c9be-4234-b1e4-e59bdc9bf340", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AccountUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9776fc44-076b-4b78-ac3e-849622ad700d", 0, "a7430f78-13e0-4a1a-98c7-72ff5397bd5c", "IdentityUser", "admin@system.com", true, false, null, "ADMIN@SYSTEM.COM", "ADMIN@SYSTEM.COM", "AQAAAAIAAYagAAAAEKoZgfR0Wle679kZYFWPcsM18A5bSGJS2zv1nEJ7KcAA+b7TqKKwG78ujSxvS0VfNQ==", null, false, "b9da3180-9467-468e-baec-f856c97bf08a", false, "admin@system.com" });

            migrationBuilder.InsertData(
                table: "AccountUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d61700b6-c9be-4234-b1e4-e59bdc9bf340", "9776fc44-076b-4b78-ac3e-849622ad700d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "95becdc5-4823-42fa-b8d6-3342b471be7a");

            migrationBuilder.DeleteData(
                table: "AccountUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d61700b6-c9be-4234-b1e4-e59bdc9bf340", "9776fc44-076b-4b78-ac3e-849622ad700d" });

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "d61700b6-c9be-4234-b1e4-e59bdc9bf340");

            migrationBuilder.DeleteData(
                table: "AccountUsers",
                keyColumn: "Id",
                keyValue: "9776fc44-076b-4b78-ac3e-849622ad700d");

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61684a0e-8a1e-4530-b80b-f731439a5613", null, "Admin", "ADMIN" },
                    { "91b26e95-b052-4198-b482-c365c17762a4", null, "Usuario", "USUARIO" }
                });
        }
    }
}
