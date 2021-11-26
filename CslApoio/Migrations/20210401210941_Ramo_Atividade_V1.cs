using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CslApoio.Migrations
{
    public partial class Ramo_Atividade_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AtividadeId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FimAtividade",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InicioAtividade",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RamoAtividadeId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StatusTerceiroId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RamoAtividade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RamoAtividade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusTerceiro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTerceiro", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_AtividadeId",
                table: "Funcionarios",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_RamoAtividadeId",
                table: "Funcionarios",
                column: "RamoAtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_StatusTerceiroId",
                table: "Funcionarios",
                column: "StatusTerceiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Atividade_AtividadeId",
                table: "Funcionarios",
                column: "AtividadeId",
                principalTable: "Atividade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_RamoAtividade_RamoAtividadeId",
                table: "Funcionarios",
                column: "RamoAtividadeId",
                principalTable: "RamoAtividade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_StatusTerceiro_StatusTerceiroId",
                table: "Funcionarios",
                column: "StatusTerceiroId",
                principalTable: "StatusTerceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Atividade_AtividadeId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_RamoAtividade_RamoAtividadeId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_StatusTerceiro_StatusTerceiroId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "RamoAtividade");

            migrationBuilder.DropTable(
                name: "StatusTerceiro");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_AtividadeId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_RamoAtividadeId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_StatusTerceiroId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "AtividadeId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "FimAtividade",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "InicioAtividade",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "RamoAtividadeId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "StatusTerceiroId",
                table: "Funcionarios");
        }
    }
}
