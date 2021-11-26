using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CslApoio.Migrations
{
    public partial class AcessoLogico_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AcessoFisicoId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AcessoLogicoId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GrupoAtendimentoId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Prorroga",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AcessoFisico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessoFisico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcessoLogico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessoLogico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoAtendimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoAtendimento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_AcessoFisicoId",
                table: "Funcionarios",
                column: "AcessoFisicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_AcessoLogicoId",
                table: "Funcionarios",
                column: "AcessoLogicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_GrupoAtendimentoId",
                table: "Funcionarios",
                column: "GrupoAtendimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_AcessoFisico_AcessoFisicoId",
                table: "Funcionarios",
                column: "AcessoFisicoId",
                principalTable: "AcessoFisico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_AcessoLogico_AcessoLogicoId",
                table: "Funcionarios",
                column: "AcessoLogicoId",
                principalTable: "AcessoLogico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_GrupoAtendimento_GrupoAtendimentoId",
                table: "Funcionarios",
                column: "GrupoAtendimentoId",
                principalTable: "GrupoAtendimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_AcessoFisico_AcessoFisicoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_AcessoLogico_AcessoLogicoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_GrupoAtendimento_GrupoAtendimentoId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "AcessoFisico");

            migrationBuilder.DropTable(
                name: "AcessoLogico");

            migrationBuilder.DropTable(
                name: "GrupoAtendimento");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_AcessoFisicoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_AcessoLogicoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_GrupoAtendimentoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "AcessoFisicoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "AcessoLogicoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "GrupoAtendimentoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Prorroga",
                table: "Funcionarios");
        }
    }
}
