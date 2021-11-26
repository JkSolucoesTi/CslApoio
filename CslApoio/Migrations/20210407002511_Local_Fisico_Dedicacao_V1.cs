using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CslApoio.Migrations
{
    public partial class Local_Fisico_Dedicacao_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContatoClienteId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DedicadoTelefonicaId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DependenciaId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ContatoCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DedicadoTelefonica",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DedicadoTelefonica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dependencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependencia", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ContatoClienteId",
                table: "Funcionarios",
                column: "ContatoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DedicadoTelefonicaId",
                table: "Funcionarios",
                column: "DedicadoTelefonicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DependenciaId",
                table: "Funcionarios",
                column: "DependenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_ContatoCliente_ContatoClienteId",
                table: "Funcionarios",
                column: "ContatoClienteId",
                principalTable: "ContatoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_DedicadoTelefonica_DedicadoTelefonicaId",
                table: "Funcionarios",
                column: "DedicadoTelefonicaId",
                principalTable: "DedicadoTelefonica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Dependencia_DependenciaId",
                table: "Funcionarios",
                column: "DependenciaId",
                principalTable: "Dependencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_ContatoCliente_ContatoClienteId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_DedicadoTelefonica_DedicadoTelefonicaId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Dependencia_DependenciaId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "ContatoCliente");

            migrationBuilder.DropTable(
                name: "DedicadoTelefonica");

            migrationBuilder.DropTable(
                name: "Dependencia");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_ContatoClienteId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_DedicadoTelefonicaId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_DependenciaId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "ContatoClienteId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "DedicadoTelefonicaId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "DependenciaId",
                table: "Funcionarios");
        }
    }
}
