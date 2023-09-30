using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyDoctorAPI.Migrations
{
    /// <inheritdoc />
    public partial class tenpic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d498880-0e88-42e2-9ab0-20b78e11c7c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4eb0142-0858-4e2e-8dee-b947183bf328");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89676729-bb53-4714-8200-ca0ef7bfd4a9", "3", "Writer", "Writer" },
                    { "95b45bbb-5fa4-464e-8f9f-cb0cc6e7f8d8", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Name", "Section", "Type" },
                values: new object[,]
                {
                    { 11, "Admin", "Nga7atna", "Nga7at7" },
                    { 12, "Admin", "Nga7atna", "Nga7at8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89676729-bb53-4714-8200-ca0ef7bfd4a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95b45bbb-5fa4-464e-8f9f-cb0cc6e7f8d8");

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d498880-0e88-42e2-9ab0-20b78e11c7c9", "1", "Admin", "Admin" },
                    { "b4eb0142-0858-4e2e-8dee-b947183bf328", "3", "Writer", "Writer" }
                });
        }
    }
}
