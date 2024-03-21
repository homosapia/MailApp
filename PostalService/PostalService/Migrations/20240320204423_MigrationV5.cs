using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PostalService.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Writings_UniqueId_MailIdId",
                table: "Writings");

            migrationBuilder.DropIndex(
                name: "IX_Writings_MailIdId",
                table: "Writings");

            migrationBuilder.DropColumn(
                name: "MailIdId",
                table: "Writings");

            migrationBuilder.RenameColumn(
                name: "Validity",
                table: "UniqueId",
                newName: "UintValidity");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UniqueId",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "UintId",
                table: "UniqueId",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "WritingId",
                table: "UniqueId",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UniqueId_WritingId",
                table: "UniqueId",
                column: "WritingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UniqueId_Writings_WritingId",
                table: "UniqueId",
                column: "WritingId",
                principalTable: "Writings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniqueId_Writings_WritingId",
                table: "UniqueId");

            migrationBuilder.DropIndex(
                name: "IX_UniqueId_WritingId",
                table: "UniqueId");

            migrationBuilder.DropColumn(
                name: "UintId",
                table: "UniqueId");

            migrationBuilder.DropColumn(
                name: "WritingId",
                table: "UniqueId");

            migrationBuilder.RenameColumn(
                name: "UintValidity",
                table: "UniqueId",
                newName: "Validity");

            migrationBuilder.AddColumn<long>(
                name: "MailIdId",
                table: "Writings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "UniqueId",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Writings_MailIdId",
                table: "Writings",
                column: "MailIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Writings_UniqueId_MailIdId",
                table: "Writings",
                column: "MailIdId",
                principalTable: "UniqueId",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
