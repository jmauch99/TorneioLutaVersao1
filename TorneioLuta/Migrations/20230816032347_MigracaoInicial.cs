using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorneioLuta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lutadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    EstiloLuta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vitorias = table.Column<int>(type: "int", nullable: false),
                    Derrotas = table.Column<int>(type: "int", nullable: false),
                    QtdTorneiosGanhos = table.Column<int>(type: "int", nullable: false),
                    QtdEstilosDominados = table.Column<int>(type: "int", nullable: false),
                    QtdLutas = table.Column<int>(type: "int", nullable: false),
                    ParticipaDoTorneio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lutadores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lutadores");
        }
    }
}
