using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PostalService.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MailIdId",
                table: "Writings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "СompanyMemberId",
                table: "Writings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UniqueId",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Validity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueId", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Writings_СompanyMemberId",
                table: "Writings",
                column: "СompanyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Writings_MailIdId",
                table: "Writings",
                column: "MailIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Writings_Members_СompanyMemberId",
                table: "Writings",
                column: "СompanyMemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Writings_UniqueId_MailIdId",
                table: "Writings",
                column: "MailIdId",
                principalTable: "UniqueId",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Writings_Members_СompanyMemberId",
                table: "Writings");

            migrationBuilder.DropForeignKey(
                name: "FK_Writings_UniqueId_MailIdId",
                table: "Writings");

            migrationBuilder.DropTable(
                name: "UniqueId");

            migrationBuilder.DropIndex(
                name: "IX_Writings_СompanyMemberId",
                table: "Writings");

            migrationBuilder.DropIndex(
                name: "IX_Writings_MailIdId",
                table: "Writings");

            migrationBuilder.DropColumn(
                name: "MailIdId",
                table: "Writings");

            migrationBuilder.DropColumn(
                name: "СompanyMemberId",
                table: "Writings");
        }
    }
}
