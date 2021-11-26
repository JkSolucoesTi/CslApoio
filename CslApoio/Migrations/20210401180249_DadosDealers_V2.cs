using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CslApoio.Migrations
{
    public partial class DadosDealers_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_SubGrupoDealers_SubGrupoDealersId",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubGrupoDealersId",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_SubGrupoDealers_SubGrupoDealersId",
                table: "Funcionarios",
                column: "SubGrupoDealersId",
                principalTable: "SubGrupoDealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_SubGrupoDealers_SubGrupoDealersId",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubGrupoDealersId",
                table: "Funcionarios",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_SubGrupoDealers_SubGrupoDealersId",
                table: "Funcionarios",
                column: "SubGrupoDealersId",
                principalTable: "SubGrupoDealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
