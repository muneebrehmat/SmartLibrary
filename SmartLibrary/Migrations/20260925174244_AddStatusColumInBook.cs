using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusColumInBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Available",
                table: "Books",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Books",
                newName: "Available");
        }
    }
}
