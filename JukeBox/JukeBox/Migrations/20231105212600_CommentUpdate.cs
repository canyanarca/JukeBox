using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JukeBox.Migrations
{
    /// <inheritdoc />
    public partial class CommentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_UserID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Games_GameID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_GameID",
                table: "Comment");


            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "Comment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
