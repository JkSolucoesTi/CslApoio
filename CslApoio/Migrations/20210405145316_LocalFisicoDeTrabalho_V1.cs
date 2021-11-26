using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CslApoio.Migrations
{
    public partial class LocalFisicoDeTrabalho_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AndarPredioTelId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CidadePServ",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EstadoPServId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RecursosHumanosId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SitesCallCenterId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SubArea",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AndarPredioTel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AndarPredioTel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoPServ",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPServ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecursosHumanos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursosHumanos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SitesCallCenter",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitesCallCenter", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_AndarPredioTelId",
                table: "Funcionarios",
                column: "AndarPredioTelId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EmpresaId",
                table: "Funcionarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EstadoPServId",
                table: "Funcionarios",
                column: "EstadoPServId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_RecursosHumanosId",
                table: "Funcionarios",
                column: "RecursosHumanosId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SitesCallCenterId",
                table: "Funcionarios",
                column: "SitesCallCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_AndarPredioTel_AndarPredioTelId",
                table: "Funcionarios",
                column: "AndarPredioTelId",
                principalTable: "AndarPredioTel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Empresa_EmpresaId",
                table: "Funcionarios",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_EstadoPServ_EstadoPServId",
                table: "Funcionarios",
                column: "EstadoPServId",
                principalTable: "EstadoPServ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_RecursosHumanos_RecursosHumanosId",
                table: "Funcionarios",
                column: "RecursosHumanosId",
                principalTable: "RecursosHumanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_SitesCallCenter_SitesCallCenterId",
                table: "Funcionarios",
                column: "SitesCallCenterId",
                principalTable: "SitesCallCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_AndarPredioTel_AndarPredioTelId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Empresa_EmpresaId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_EstadoPServ_EstadoPServId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_RecursosHumanos_RecursosHumanosId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_SitesCallCenter_SitesCallCenterId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "AndarPredioTel");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "EstadoPServ");

            migrationBuilder.DropTable(
                name: "RecursosHumanos");

            migrationBuilder.DropTable(
                name: "SitesCallCenter");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_AndarPredioTelId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EmpresaId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EstadoPServId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_RecursosHumanosId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_SitesCallCenterId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "AndarPredioTelId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "CidadePServ",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EstadoPServId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "RecursosHumanosId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "SitesCallCenterId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "SubArea",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
