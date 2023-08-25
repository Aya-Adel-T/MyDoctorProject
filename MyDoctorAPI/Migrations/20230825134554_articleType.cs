using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyDoctorAPI.Migrations
{
    /// <inheritdoc />
    public partial class articleType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArticleType",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fbb0d83-ce7c-4290-a4dc-ebb7c20d2f90", "1", "Admin", "Admin" },
                    { "81a2a9c9-c916-4818-91af-2f779597d233", "3", "Customer", "Writer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fbb0d83-ce7c-4290-a4dc-ebb7c20d2f90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81a2a9c9-c916-4818-91af-2f779597d233");

            migrationBuilder.DropColumn(
                name: "ArticleType",
                table: "Articles");
        }
    }
}
