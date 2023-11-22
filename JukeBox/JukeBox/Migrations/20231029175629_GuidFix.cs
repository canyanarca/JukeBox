using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JukeBox.Migrations
{
    /// <inheritdoc />
    public partial class GuidFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Games",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Games",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comment",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "ID");
        }
    }
}
