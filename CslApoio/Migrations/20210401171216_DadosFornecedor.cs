using Microsoft.EntityFrameworkCore.Migrations;

namespace CslApoio.Migrations
{
    public partial class DadosFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentoCompra",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubContratada",
                table: "Funcionarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentoCompra",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Item",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "SubContratada",
                table: "Funcionarios");
        }
    }
}
