using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaCuentas.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "4c45bc8d-370d-4d63-9a3f-0f231ff704b7");

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "7d73aa4d-c1e6-4796-a2aa-12636dbb6b91");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AccountUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "AccountUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "AccountUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AccountUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "536ef52e-4527-4f42-b792-216d00d408ba", null, "Admin", "ADMIN" },
                    { "9ed398ee-71bb-48ab-a39f-11384c48f77c", null, "Usuario", "USUARIO" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "536ef52e-4527-4f42-b792-216d00d408ba");

            migrationBuilder.DeleteData(
                table: "AccountRoles",
                keyColumn: "Id",
                keyValue: "9ed398ee-71bb-48ab-a39f-11384c48f77c");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AccountUsers");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "AccountUsers");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "AccountUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AccountUsers");

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c45bc8d-370d-4d63-9a3f-0f231ff704b7", null, "Admin", "ADMIN" },
                    { "7d73aa4d-c1e6-4796-a2aa-12636dbb6b91", null, "Usuario", "USUARIO" }
                });
        }
    }
}
