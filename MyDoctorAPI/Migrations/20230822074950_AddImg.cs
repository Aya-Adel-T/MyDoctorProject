using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDoctorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Writers_AuthorID",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "NewsImg",
                table: "Articles",
                newName: "ArticleImg");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Articles",
                newName: "WriterID");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_AuthorID",
                table: "Articles",
                newName: "IX_Articles_WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Writers_WriterID",
                table: "Articles",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Writers_WriterID",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "WriterID",
                table: "Articles",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "ArticleImg",
                table: "Articles",
                newName: "NewsImg");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_WriterID",
                table: "Articles",
                newName: "IX_Articles_AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Writers_AuthorID",
                table: "Articles",
                column: "AuthorID",
                principalTable: "Writers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
