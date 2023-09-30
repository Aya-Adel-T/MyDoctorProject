using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyDoctorAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedPictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90f79ea5-d6d1-46e8-b88d-92c7cf21cb13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a16847c4-9179-4751-92db-56bea29d4575");

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d498880-0e88-42e2-9ab0-20b78e11c7c9", "1", "Admin", "Admin" },
                    { "b4eb0142-0858-4e2e-8dee-b947183bf328", "3", "Writer", "Writer" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Name", "Section", "Type" },
                values: new object[,]
                {
                    { 1, "Admin", "Slider", "Slider1" },
                    { 2, "Admin", "Slider", "Slider2" },
                    { 3, "Admin", "Slider", "Slider3" },
                    { 4, "Admin", "About", "AboutUs" },
                    { 5, "Admin", "Nga7atna", "Nga7at1" },
                    { 6, "Admin", "Nga7atna", "Nga7at2" },
                    { 7, "Admin", "Nga7atna", "Nga7at3" },
                    { 8, "Admin", "Nga7atna", "Nga7at4" },
                    { 9, "Admin", "Nga7atna", "Nga7at5" },
                    { 10, "Admin", "Nga7atna", "Nga7at6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d498880-0e88-42e2-9ab0-20b78e11c7c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4eb0142-0858-4e2e-8dee-b947183bf328");

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Pictures");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "90f79ea5-d6d1-46e8-b88d-92c7cf21cb13", "1", "Admin", "Admin" },
                    { "a16847c4-9179-4751-92db-56bea29d4575", "3", "Writer", "Writer" }
                });
        }
    }
}
