using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CslApoio.Migrations
{
    public partial class DadosDealers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubGrupoDealersId",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubGrupoDealers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGrupoDealers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SubGrupoDealersId",
                table: "Funcionarios",
                column: "SubGrupoDealersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_SubGrupoDealers_SubGrupoDealersId",
                table: "Funcionarios",
                column: "SubGrupoDealersId",
                principalTable: "SubGrupoDealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_SubGrupoDealers_SubGrupoDealersId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "SubGrupoDealers");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_SubGrupoDealersId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "SubGrupoDealersId",
                table: "Funcionarios");
        }
    }
}
