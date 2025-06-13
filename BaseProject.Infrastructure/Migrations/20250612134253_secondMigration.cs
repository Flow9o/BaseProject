using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Cars_CarId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_CarId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Bookmarks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Bookmarks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_CarId",
                table: "Bookmarks",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Cars_CarId",
                table: "Bookmarks",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
