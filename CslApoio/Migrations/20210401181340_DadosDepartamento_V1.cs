using Microsoft.EntityFrameworkCore.Migrations;

namespace CslApoio.Migrations
{
    public partial class DadosDepartamento_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Solicitante",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnidadeGestorContrato",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnidadeGestorOperacional",
                table: "Funcionarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Solicitante",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "UnidadeGestorContrato",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "UnidadeGestorOperacional",
                table: "Funcionarios");
        }
    }
}
