using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CslApoio.Models
{
    public class Funcionario : Entity
    {
        public string Matricula { get; set; }

        [DisplayName("Terceiro")]
        public Guid TerceiroId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Sobrenome")]
        public string SobreNome { get; set; }

        [DisplayName("Sexo")]
        public Guid SexoId { get; set; }

        public string Passaporte { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11,ErrorMessage = "O Campo {0} precisar ter 11 Digitos",MinimumLength = 11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string PIS { get; set; }

        [DisplayName("Estado Civil")]
        public Guid EstadoCivilId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string RG { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Emissor")]
        public string OrgaoEmissor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data de Nascimento")]
        public string DataNascimento { get; set; }

        [DisplayName("Nacionalidade")]
        public Guid NacionalidadeId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Telefone { get; set; }

        [DisplayName("Escolaridade")]
        public Guid EscolaridadeId { get; set; }

        [DisplayName("Certificado")]
        public Guid CertificadoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Documento de Compra")]
        public string DocumentoCompra { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Item { get; set; }

        [StringLength(14, ErrorMessage = "O Campo {0} precisar ter 11 Digitos", MinimumLength = 14)]
        [DisplayName("CNPJ - SubContratada")]
        public string SubContratada { get; set; }

        [Required()]
        [DisplayName("SubGrupo Dealers")]
        public Guid SubGrupoDealersId { get; set; }
        
        [DisplayName("Status do Terceiro")]
        public Guid StatusTerceiroId { get; set; }
        
        [DisplayName("Atividade")]
        public Guid AtividadeId { get; set; }
        
        [DisplayName("Ramo de Atividade")]
        public Guid RamoAtividadeId { get; set; }
        
        [DisplayName("Emprasa")]
        public Guid EmpresaId { get; set; }
        
        [DisplayName("Area Recursos Humanos")]
        public Guid RecursosHumanosId { get; set; }
        
        [DisplayName("Estado Prestação")]
        public Guid EstadoPServId { get; set; }

        [DisplayName("Sites Call Center")]
        public Guid SitesCallCenterId { get; set; }
        
        [DisplayName("Predio Telefonica")]
        public Guid AndarPredioTelId { get; set; }

        //Dados Dealers
        [StringLength(14, ErrorMessage = "O Campo {0} precisar ter 11 Digitos", MinimumLength = 14)]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Unidade Gestor Operacional")]
        public string UnidadeGestorOperacional { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Unidade Gestor Contrato")]
        public string UnidadeGestorContrato { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Solicitante { get; set; }

        [DisplayName("Inicio Atividade")]
        public string InicioAtividade { get; set; }
        
        [DisplayName("Fim Atividade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string FimAtividade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string SubArea { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [DisplayName("Cidade Prestação")]
        public string CidadePServ { get; set; }

        public string Prorroga { get; set; }
        [DisplayName("Acesso Lógico")]
        public Guid AcessoLogicoId { get; set; }
        [DisplayName("Acesso Físico")]
        public Guid AcessoFisicoId { get; set; }
        [DisplayName("Grupo  de Atendimento")]
        public Guid GrupoAtendimentoId { get; set; }
        [DisplayName("Dependencias")]
        public Guid DependenciaId { get; set; }
        [DisplayName("Contato Cliente")]
        public Guid ContatoClienteId { get;set;}
        [DisplayName("Dedicado Telefonica")]
        public Guid DedicadoTelefonicaId { get;set;}

        [DisplayName("Ação")]
        public Guid AcaoId { get; set; }

        //Relacionamento EF 1 => N
        public Certificado Certificado { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Nacionalidade Nacionalidade { get; set; }       
        public Sexo Sexo { get; set; }
        public Terceiro Terceiro { get; set; }
        public SubGrupoDealers SubGrupoDealers { get; set; }
        public StatusTerceiro StatusTerceiro { get; set; }
        public Atividade Atividade { get; set; }
        public RamoAtividade RamoAtividade { get; set; }
        public Empresa Empresa { get; set; }
        public RecursosHumanos RecursosHumanos { get; set; }
        public EstadoPServ EstadoPServ { get; set; }
        public SitesCallCenter SitesCallCenter { get; set; }
        public AndarPredioTel AndarPredioTel { get; set; }
        public AcessoFisico AcessoFisico { get; set; }
        public AcessoLogico AcessoLogico { get; set; }
        public GrupoAtendimento GrupoAtendimento { get; set; }
        public Dependencia Dependencia { get; set; }
        public ContatoCliente ContatoCliente { get; set; }
        public DedicadoTelefonica DedicadoTelefonica { get; set; }
        public Acao Acao { get; set; }

    }

}
