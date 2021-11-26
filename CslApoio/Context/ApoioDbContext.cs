using CslApoio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CslApoio.Context
{
    public class ApoioDbContext : IdentityDbContext
    {
        public ApoioDbContext(DbContextOptions<ApoioDbContext> options) 
            : base(options)
        {        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Certificado> Certificados {get;set;}
        public DbSet<Escolaridade> TipoEscolaridade { get; set; }
        public DbSet<EstadoCivil> TipoEstadoCivil { get; set; }
        public DbSet<Nacionalidade> TipoNacionalidade { get; set; }
        public DbSet<Sexo> TipoSexo { get; set; }
        public DbSet<Terceiro> TipoTerceiro { get; set; }
        public DbSet<SubGrupoDealers> SubGrupoDealers { get; set; }
        public DbSet<CslApoio.Models.Atividade> Atividade { get; set; }
        public DbSet<CslApoio.Models.RamoAtividade> RamoAtividade { get; set; }
        public DbSet<CslApoio.Models.StatusTerceiro> StatusTerceiro { get; set; }
        public DbSet<CslApoio.Models.Empresa> Empresa { get; set; }
        public DbSet<CslApoio.Models.RecursosHumanos> RecursosHumanos { get; set; }
        public DbSet<CslApoio.Models.SitesCallCenter> SitesCallCenter { get; set; }
        public DbSet<CslApoio.Models.EstadoPServ> EstadoPServ { get; set; }
        public DbSet<CslApoio.Models.AndarPredioTel> AndarPredioTel { get; set; }
        public DbSet<CslApoio.Models.AcessoFisico> AcessoFisico { get; set; }
        public DbSet<CslApoio.Models.AcessoLogico> AcessoLogico { get; set; }
        public DbSet<CslApoio.Models.GrupoAtendimento> GrupoAtendimento { get; set; }
        public DbSet<CslApoio.Models.Dependencia> Dependencia { get; set; }
        public DbSet<CslApoio.Models.DedicadoTelefonica> DedicadoTelefonica { get; set; }
        public DbSet<CslApoio.Models.ContatoCliente> ContatoCliente { get; set; }
        public DbSet<CslApoio.Models.Acao> Acao { get; set; }
    }
}
