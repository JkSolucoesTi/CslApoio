using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CslApoio.Migrations
{
    public partial class Acao_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AcaoId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Acao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_AcaoId",
                table: "Funcionarios",
                column: "AcaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Acao_AcaoId",
                table: "Funcionarios",
                column: "AcaoId",
                principalTable: "Acao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Acao_AcaoId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Acao");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_AcaoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "AcaoId",
                table: "Funcionarios");
        }
    }
}
