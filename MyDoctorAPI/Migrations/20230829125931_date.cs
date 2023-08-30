using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyDoctorAPI.Migrations
{
    /// <inheritdoc />
    public partial class date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06c58575-ef72-4a93-a142-b9cac22c6db8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d6a6d61-ced6-4e63-88c5-0f8dc573d491");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12417e9d-f794-4d96-9b93-c9b42900e1fa", "1", "Admin", "Admin" },
                    { "a43b11fd-2ca5-443b-ac53-56af1c7c73a7", "3", "Customer", "Writer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12417e9d-f794-4d96-9b93-c9b42900e1fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a43b11fd-2ca5-443b-ac53-56af1c7c73a7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06c58575-ef72-4a93-a142-b9cac22c6db8", "3", "Customer", "Writer" },
                    { "7d6a6d61-ced6-4e63-88c5-0f8dc573d491", "1", "Admin", "Admin" }
                });
        }
    }
}
