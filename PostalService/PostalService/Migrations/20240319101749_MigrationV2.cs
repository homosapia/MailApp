using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostalService.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Writings");

            migrationBuilder.DropColumn(
                name: "OutgoingSMTP",
                table: "Members");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Writings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OutgoingSMTP",
                table: "Members",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
