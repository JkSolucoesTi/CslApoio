// <auto-generated />
using System;
using CslApoio.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CslApoio.Migrations
{
    [DbContext(typeof(ApoioDbContext))]
    [Migration("20210331172053_InitialCreate_v1")]
    partial class InitialCreate_v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CslApoio.Models.Certificado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opcoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Certificados");
                });

            modelBuilder.Entity("CslApoio.Models.Escolaridade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opcoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoEscolaridade");
                });

            modelBuilder.Entity("CslApoio.Models.EstadoCivil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opcoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoEstadoCivil");
                });

            modelBuilder.Entity("CslApoio.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CertificadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EscolaridadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstadoCivilId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Matricula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NacionalidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrgaoEmissor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PIS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passaporte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SexoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SobreNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TerceiroId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CertificadoId");

                    b.HasIndex("EscolaridadeId");

                    b.HasIndex("EstadoCivilId");

                    b.HasIndex("NacionalidadeId");

                    b.HasIndex("SexoId");

                    b.HasIndex("TerceiroId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("CslApoio.Models.Nacionalidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opcoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoNacionalidade");
                });

            modelBuilder.Entity("CslApoio.Models.Sexo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opcoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoSexo");
                });

            modelBuilder.Entity("CslApoio.Models.Terceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opcoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoTerceiro");
                });

            modelBuilder.Entity("CslApoio.Models.Funcionario", b =>
                {
                    b.HasOne("CslApoio.Models.Certificado", "Certificado")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CertificadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CslApoio.Models.Escolaridade", "Escolaridade")
                        .WithMany("Funcionarios")
                        .HasForeignKey("EscolaridadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CslApoio.Models.EstadoCivil", "EstadoCivil")
                        .WithMany("Funcionarios")
                        .HasForeignKey("EstadoCivilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CslApoio.Models.Nacionalidade", "Nacionalidade")
                        .WithMany("Funcionarios")
                        .HasForeignKey("NacionalidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CslApoio.Models.Sexo", "Sexo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("SexoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CslApoio.Models.Terceiro", "Terceiro")
                        .WithMany("Funcionarios")
                        .HasForeignKey("TerceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
