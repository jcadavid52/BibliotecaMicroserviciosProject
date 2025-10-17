using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaCuentas.Identity.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAdminDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "38969cb9-9f09-43c9-b5d6-e76353f8036e");

            migrationBuilder.DeleteData(
                table: "AccountUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "750db58b-ae59-47ea-83b4-8729d6bbd338", "c34170e5-fc6a-4e2f-a1b9-3be94a90a0a3" });

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "750db58b-ae59-47ea-83b4-8729d6bbd338");

            migrationBuilder.DeleteData(
                table: "AccountUsers",
                keyColumn: "Id",
                keyValue: "c34170e5-fc6a-4e2f-a1b9-3be94a90a0a3");

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61684a0e-8a1e-4530-b80b-f731439a5613", null, "Admin", "ADMIN" },
                    { "91b26e95-b052-4198-b482-c365c17762a4", null, "Usuario", "USUARIO" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "38969cb9-9f09-43c9-b5d6-e76353f8036e", null, "Usuario", "USUARIO" },
                    { "750db58b-ae59-47ea-83b4-8729d6bbd338", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AccountUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c34170e5-fc6a-4e2f-a1b9-3be94a90a0a3", 0, "acffb289-c5b0-43b9-8fc9-c2ecae9f9aa9", "IdentityUser", "admin@system.com", true, false, null, "ADMIN@SYSTEM.COM", "ADMIN@SYSTEM.COM", "AQAAAAIAAYagAAAAEO52qo35IqHnzBTEVeaUTlKLf22RtSoZqXgh8+VSYnW9w4iViWgo4gAVRZE8C7ZsaQ==", null, false, "ca2ffe64-7b8b-423e-a846-401049630d04", false, "admin@system.com" });

            migrationBuilder.InsertData(
                table: "AccountUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "750db58b-ae59-47ea-83b4-8729d6bbd338", "c34170e5-fc6a-4e2f-a1b9-3be94a90a0a3" });
        }
    }
}
