using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_Labb1.Migrations
{
    /// <inheritdoc />
    public partial class MenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "MenuItems",
                newName: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "MenuItems",
                newName: "MenuId");
        }
    }
}
