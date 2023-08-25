using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyDoctorAPI.Migrations
{
    /// <inheritdoc />
    public partial class ArticleStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fbb0d83-ce7c-4290-a4dc-ebb7c20d2f90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81a2a9c9-c916-4818-91af-2f779597d233");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06c58575-ef72-4a93-a142-b9cac22c6db8", "3", "Customer", "Writer" },
                    { "7d6a6d61-ced6-4e63-88c5-0f8dc573d491", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06c58575-ef72-4a93-a142-b9cac22c6db8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d6a6d61-ced6-4e63-88c5-0f8dc573d491");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fbb0d83-ce7c-4290-a4dc-ebb7c20d2f90", "1", "Admin", "Admin" },
                    { "81a2a9c9-c916-4818-91af-2f779597d233", "3", "Customer", "Writer" }
                });
        }
    }
}
