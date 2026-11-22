using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Available",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Books");
        }
    }
}
