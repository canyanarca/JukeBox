using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JukeBox.Migrations
{
    /// <inheritdoc />
    public partial class AddedCatIdColumnToGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Games SET CategoryId = (SELECT Id FROM GameCategory WHERE CategoryName = 'Action')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Games");
        }
    }
}
