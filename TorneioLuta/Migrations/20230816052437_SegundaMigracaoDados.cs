using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorneioLuta.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracaoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstiloLuta",
                table: "Lutadores",
                newName: "EstilosDeLutaList");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Lutadores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstilosDeLutaList",
                table: "Lutadores",
                newName: "EstiloLuta");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Lutadores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
