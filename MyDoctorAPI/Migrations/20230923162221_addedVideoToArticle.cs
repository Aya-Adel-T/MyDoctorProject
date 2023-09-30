using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyDoctorAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedVideoToArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ff777f5-e5cc-446e-85cf-09dc1bfb8d95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb93409a-7840-444e-9bc5-168d8a33a806");

            migrationBuilder.AddColumn<string>(
                name: "ArticleVideo",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "376d36f1-733e-49e6-8e61-03f018c1601d", "3", "Writer", "Writer" },
                    { "5caa1eae-2536-4d5b-8980-78be48f87b8a", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "376d36f1-733e-49e6-8e61-03f018c1601d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5caa1eae-2536-4d5b-8980-78be48f87b8a");

            migrationBuilder.DropColumn(
                name: "ArticleVideo",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ff777f5-e5cc-446e-85cf-09dc1bfb8d95", "3", "Writer", "Writer" },
                    { "eb93409a-7840-444e-9bc5-168d8a33a806", "1", "Admin", "Admin" }
                });
        }
    }
}
