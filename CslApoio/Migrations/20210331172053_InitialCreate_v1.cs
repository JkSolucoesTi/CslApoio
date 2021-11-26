using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CslApoio.Migrations
{
    public partial class InitialCreate_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEscolaridade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEscolaridade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEstadoCivil",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEstadoCivil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoNacionalidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNacionalidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSexo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTerceiro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Opcoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTerceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Matricula = table.Column<string>(nullable: true),
                    TerceiroId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    SobreNome = table.Column<string>(nullable: true),
                    SexoId = table.Column<Guid>(nullable: false),
                    Passaporte = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    PIS = table.Column<string>(nullable: true),
                    EstadoCivilId = table.Column<Guid>(nullable: false),
                    RG = table.Column<string>(nullable: true),
                    OrgaoEmissor = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    NacionalidadeId = table.Column<Guid>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    EscolaridadeId = table.Column<Guid>(nullable: false),
                    CertificadoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Certificados_CertificadoId",
                        column: x => x.CertificadoId,
                        principalTable: "Certificados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_TipoEscolaridade_EscolaridadeId",
                        column: x => x.EscolaridadeId,
                        principalTable: "TipoEscolaridade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_TipoEstadoCivil_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "TipoEstadoCivil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_TipoNacionalidade_NacionalidadeId",
                        column: x => x.NacionalidadeId,
                        principalTable: "TipoNacionalidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_TipoSexo_SexoId",
                        column: x => x.SexoId,
                        principalTable: "TipoSexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_TipoTerceiro_TerceiroId",
                        column: x => x.TerceiroId,
                        principalTable: "TipoTerceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CertificadoId",
                table: "Funcionarios",
                column: "CertificadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EscolaridadeId",
                table: "Funcionarios",
                column: "EscolaridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EstadoCivilId",
                table: "Funcionarios",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_NacionalidadeId",
                table: "Funcionarios",
                column: "NacionalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SexoId",
                table: "Funcionarios",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_TerceiroId",
                table: "Funcionarios",
                column: "TerceiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "TipoEscolaridade");

            migrationBuilder.DropTable(
                name: "TipoEstadoCivil");

            migrationBuilder.DropTable(
                name: "TipoNacionalidade");

            migrationBuilder.DropTable(
                name: "TipoSexo");

            migrationBuilder.DropTable(
                name: "TipoTerceiro");
        }
    }
}
