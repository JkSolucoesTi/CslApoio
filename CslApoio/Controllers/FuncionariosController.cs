using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CslApoio.Context;
using CslApoio.Models;
using ClosedXML.Excel;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CslApoio.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApoioDbContext _context;
        private readonly IConfiguration configure;
        public FuncionariosController(ApoioDbContext context, IConfiguration _configuration )
        {
            _context = context;
            this.configure = _configuration;
        }

        public async Task<IActionResult> Index()
        {

            var data = new DateTime(2020,01,01);
            var data2 = new DateTime(2021, 04, 22);

            SqlConnection sql = new SqlConnection(configure.GetConnectionString("MyConectionDB"));
            
                sql.Open();
                SqlCommand sqlCmd = new SqlCommand("SOMA_DESPESAS_ADMINISTRATIVAS", sql);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("DATA_INICIO",data);
                sqlCmd.Parameters.AddWithValue("DATA_FIM",data2);
                await sqlCmd.ExecuteNonQueryAsync();
                sql.Close();            

            var apoioDbContext = _context.Funcionarios
                .Include(f => f.Acao)
                .Include(f => f.Certificado)
                .Include(f => f.Escolaridade)
                .Include(f => f.EstadoCivil)
                .Include(f => f.Nacionalidade)
                .Include(f => f.Sexo)
                .Include(f => f.Terceiro)
                .Include(f => f.SubGrupoDealers)
                .Include(f => f.StatusTerceiro)
                .Include(f => f.Atividade)
                .Include(f => f.RamoAtividade)
                .Include(f => f.Empresa)
                .Include(f => f.RecursosHumanos)
                .Include(f => f.EstadoPServ)
                .Include(f => f.SitesCallCenter)
                .Include(f => f.AndarPredioTel)
                .Include(f => f.AcessoLogico)
                .Include(f => f.AcessoFisico)
                .Include(f => f.GrupoAtendimento)
                .Include(f => f.DedicadoTelefonica)
                .Include(f => f.Dependencia)
                .Include(f => f.ContatoCliente).OrderBy(p => p.ContatoCliente.Opcoes);
           
            return View(await apoioDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var funcionario = await _context.Funcionarios
                .Include(f => f.Acao)
                .Include(f => f.Certificado)
                .Include(f => f.Escolaridade)
                .Include(f => f.EstadoCivil)
                .Include(f => f.Nacionalidade)
                .Include(f => f.Sexo)
                .Include(f => f.Terceiro)
                .Include(f => f.SubGrupoDealers)
                .Include(f => f.StatusTerceiro)
                .Include(f => f.Atividade)
                .Include(f => f.RamoAtividade)
                .Include(f => f.Empresa)
                .Include(f => f.RecursosHumanos)
                .Include(f => f.EstadoPServ)
                .Include(f => f.SitesCallCenter)
                .Include(f => f.AndarPredioTel)
                .Include(f => f.AcessoLogico)
                .Include(f => f.AcessoFisico)
                .Include(f => f.GrupoAtendimento)
                .Include(f => f.DedicadoTelefonica)
                .Include(f => f.Dependencia)
                .Include(f => f.ContatoCliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        public IActionResult Create()
        {
            ViewData["CertificadoId"] = new SelectList(_context.Certificados, "Id", "Opcoes").OrderByDescending(p => p.Value);
            ViewData["EscolaridadeId"] = new SelectList(_context.TipoEscolaridade, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["EstadoCivilId"] = new SelectList(_context.TipoEstadoCivil, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["NacionalidadeId"] = new SelectList(_context.TipoNacionalidade, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["SexoId"] = new SelectList(_context.TipoSexo, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["TerceiroId"] = new SelectList(_context.TipoTerceiro, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["SubGrupoDealersId"] = new SelectList(_context.SubGrupoDealers, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["StatusTerceiroId"] = new SelectList(_context.StatusTerceiro, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["AtividadeId"] = new SelectList(_context.Atividade, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["RamoAtividadeId"] = new SelectList(_context.RamoAtividade, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["RecursosHumanosId"] = new SelectList(_context.RecursosHumanos, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["EstadoPServId"] = new SelectList(_context.EstadoPServ, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["SitesCallCenterId"] = new SelectList(_context.SitesCallCenter, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["AndarPredioTelId"] = new SelectList(_context.AndarPredioTel, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["AcessoLogicoId"] = new SelectList(_context.AcessoLogico, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["AcessoFisicoId"] = new SelectList(_context.AcessoFisico, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["GrupoAtendimentoId"] = new SelectList(_context.GrupoAtendimento, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["DependenciaId"] = new SelectList(_context.Dependencia, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["ContatoClienteId"] = new SelectList(_context.ContatoCliente, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["DedicadoTelefonicaId"] = new SelectList(_context.DedicadoTelefonica, "Id", "Opcoes").OrderBy(p => p.Text);
            ViewData["AcaoId"] = new SelectList(_context.Acao, "Id", "Opcoes").OrderBy(p => p.Text);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                funcionario.InicioAtividade = DateTime.Now.ToShortDateString();
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CertificadoId"] = new SelectList(_context.Certificados, "Id", "Opcoes", funcionario.CertificadoId);
            ViewData["EscolaridadeId"] = new SelectList(_context.TipoEscolaridade, "Id", "Opcoes", funcionario.EscolaridadeId);
            ViewData["EstadoCivilId"] = new SelectList(_context.TipoEstadoCivil, "Id", "Opcoes", funcionario.EstadoCivilId);
            ViewData["NacionalidadeId"] = new SelectList(_context.TipoNacionalidade, "Id", "Opcoes", funcionario.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(_context.TipoSexo, "Id", "Opcoes", funcionario.SexoId);
            ViewData["TerceiroId"] = new SelectList(_context.TipoTerceiro, "Id", "Opcoes", funcionario.TerceiroId);
            ViewData["SubGrupoDealersId"] = new SelectList(_context.SubGrupoDealers, "Id", "Opcoes",funcionario.SubGrupoDealersId);
            ViewData["StatusTerceiroId"] = new SelectList(_context.StatusTerceiro, "Id", "Opcoes",funcionario.StatusTerceiroId);
            ViewData["AtividadeId"] = new SelectList(_context.Atividade, "Id", "Opcoes",funcionario.AtividadeId);
            ViewData["RamoAtividadeId"] = new SelectList(_context.RamoAtividade, "Id", "Opcoes",funcionario.RamoAtividadeId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Opcoes",funcionario.EmpresaId);
            ViewData["RecursosHumanosId"] = new SelectList(_context.RecursosHumanos, "Id", "Opcoes",funcionario.RecursosHumanosId);
            ViewData["EstadoPServId"] = new SelectList(_context.EstadoPServ, "Id", "Opcoes",funcionario.EstadoPServId);
            ViewData["SitesCallCenterId"] = new SelectList(_context.SitesCallCenter, "Id", "Opcoes",funcionario.SitesCallCenterId);
            ViewData["AndarPredioTelId"] = new SelectList(_context.AndarPredioTel, "Id", "Opcoes", funcionario.AndarPredioTelId);
            ViewData["AcessoLogicoId"] = new SelectList(_context.AcessoLogico, "Id", "Opcoes",funcionario.AcessoLogicoId);
            ViewData["AcessoFisicoId"] = new SelectList(_context.AcessoFisico, "Id", "Opcoes",funcionario.AcessoFisicoId);
            ViewData["GrupoAtendimentoId"] = new SelectList(_context.GrupoAtendimento, "Id", "Opcoes",funcionario.GrupoAtendimentoId);
            ViewData["DependenciaId"] = new SelectList(_context.Dependencia, "Id", "Opcoes",funcionario.DependenciaId);
            ViewData["ContatoClienteId"] = new SelectList(_context.ContatoCliente, "Id", "Opcoes",funcionario.ContatoClienteId);
            ViewData["DedicadoTelefonicaId"] = new SelectList(_context.DedicadoTelefonica, "Id", "Opcoes",funcionario.DedicadoTelefonicaId);
            ViewData["AcaoId"] = new SelectList(_context.Acao, "Id", "Opcoes", funcionario.AcaoId);

            return View(funcionario);
        }

        public async Task<IActionResult> Edit(Guid id)
        {         
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["CertificadoId"] = new SelectList(_context.Certificados, "Id", "Opcoes", funcionario.CertificadoId);
            ViewData["EscolaridadeId"] = new SelectList(_context.TipoEscolaridade, "Id", "Opcoes", funcionario.EscolaridadeId);
            ViewData["EstadoCivilId"] = new SelectList(_context.TipoEstadoCivil, "Id", "Opcoes", funcionario.EstadoCivilId);
            ViewData["NacionalidadeId"] = new SelectList(_context.TipoNacionalidade, "Id", "Opcoes", funcionario.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(_context.TipoSexo, "Id", "Opcoes", funcionario.SexoId);
            ViewData["TerceiroId"] = new SelectList(_context.TipoTerceiro, "Id", "Opcoes", funcionario.TerceiroId);
            ViewData["SubGrupoDealersId"] = new SelectList(_context.SubGrupoDealers, "Id", "Opcoes", funcionario.SubGrupoDealersId);
            ViewData["StatusTerceiroId"] = new SelectList(_context.StatusTerceiro, "Id", "Opcoes", funcionario.StatusTerceiroId);
            ViewData["AtividadeId"] = new SelectList(_context.Atividade, "Id", "Opcoes", funcionario.AtividadeId);
            ViewData["RamoAtividadeId"] = new SelectList(_context.RamoAtividade, "Id", "Opcoes", funcionario.RamoAtividadeId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Opcoes", funcionario.EmpresaId);
            ViewData["RecursosHumanosId"] = new SelectList(_context.RecursosHumanos, "Id", "Opcoes", funcionario.RecursosHumanosId);
            ViewData["EstadoPServId"] = new SelectList(_context.EstadoPServ, "Id", "Opcoes", funcionario.EstadoPServId);
            ViewData["SitesCallCenterId"] = new SelectList(_context.SitesCallCenter, "Id", "Opcoes", funcionario.SitesCallCenterId);
            ViewData["AndarPredioTelId"] = new SelectList(_context.AndarPredioTel, "Id", "Opcoes", funcionario.AndarPredioTelId);
            ViewData["AcessoLogicoId"] = new SelectList(_context.AcessoLogico, "Id", "Opcoes", funcionario.AcessoLogicoId);
            ViewData["AcessoFisicoId"] = new SelectList(_context.AcessoFisico, "Id", "Opcoes", funcionario.AcessoFisicoId);
            ViewData["GrupoAtendimentoId"] = new SelectList(_context.GrupoAtendimento, "Id", "Opcoes", funcionario.GrupoAtendimentoId);
            ViewData["DependenciaId"] = new SelectList(_context.Dependencia, "Id", "Opcoes", funcionario.DependenciaId);
            ViewData["ContatoClienteId"] = new SelectList(_context.ContatoCliente, "Id", "Opcoes", funcionario.ContatoClienteId);
            ViewData["DedicadoTelefonicaId"] = new SelectList(_context.DedicadoTelefonica, "Id", "Opcoes", funcionario.DedicadoTelefonicaId);
            ViewData["AcaoId"] = new SelectList(_context.Acao, "Id", "Opcoes", funcionario.AcaoId);


            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CertificadoId"] = new SelectList(_context.Certificados, "Id", "Opcoes", funcionario.CertificadoId);
            ViewData["EscolaridadeId"] = new SelectList(_context.TipoEscolaridade, "Id", "Opcoes", funcionario.EscolaridadeId);
            ViewData["EstadoCivilId"] = new SelectList(_context.TipoEstadoCivil, "Id", "Opcoes", funcionario.EstadoCivilId);
            ViewData["NacionalidadeId"] = new SelectList(_context.TipoNacionalidade, "Id", "Opcoes", funcionario.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(_context.TipoSexo, "Id", "Opcoes", funcionario.SexoId);
            ViewData["TerceiroId"] = new SelectList(_context.TipoTerceiro, "Id", "Opcoes", funcionario.TerceiroId);
            ViewData["SubGrupoDealersId"] = new SelectList(_context.SubGrupoDealers, "Id", "Opcoes", funcionario.SubGrupoDealersId);
            ViewData["StatusTerceiroId"] = new SelectList(_context.StatusTerceiro, "Id", "Opcoes", funcionario.StatusTerceiroId);
            ViewData["AtividadeId"] = new SelectList(_context.Atividade, "Id", "Opcoes", funcionario.AtividadeId);
            ViewData["RamoAtividadeId"] = new SelectList(_context.RamoAtividade, "Id", "Opcoes", funcionario.RamoAtividadeId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Opcoes", funcionario.EmpresaId);
            ViewData["RecursosHumanosId"] = new SelectList(_context.RecursosHumanos, "Id", "Opcoes", funcionario.RecursosHumanosId);
            ViewData["EstadoPServId"] = new SelectList(_context.EstadoPServ, "Id", "Opcoes", funcionario.EstadoPServId);
            ViewData["SitesCallCenterId"] = new SelectList(_context.SitesCallCenter, "Id", "Opcoes", funcionario.SitesCallCenterId);
            ViewData["AndarPredioTelId"] = new SelectList(_context.AndarPredioTel, "Id", "Opcoes", funcionario.AndarPredioTelId);
            ViewData["AcessoLogicoId"] = new SelectList(_context.AcessoLogico, "Id", "Opcoes", funcionario.AcessoLogicoId);
            ViewData["AcessoFisicoId"] = new SelectList(_context.AcessoFisico, "Id", "Opcoes", funcionario.AcessoFisicoId);
            ViewData["GrupoAtendimentoId"] = new SelectList(_context.GrupoAtendimento, "Id", "Opcoes", funcionario.GrupoAtendimentoId);
            ViewData["DependenciaId"] = new SelectList(_context.Dependencia, "Id", "Opcoes", funcionario.DependenciaId);
            ViewData["ContatoClienteId"] = new SelectList(_context.ContatoCliente, "Id", "Opcoes", funcionario.ContatoClienteId);
            ViewData["DedicadoTelefonicaId"] = new SelectList(_context.DedicadoTelefonica, "Id", "Opcoes", funcionario.DedicadoTelefonicaId);
            ViewData["AcaoId"] = new SelectList(_context.Acao, "Id", "Opcoes", funcionario.AcaoId);


            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var funcionario = await _context.Funcionarios
                      .Include(f => f.Acao)
                      .Include(f => f.Certificado)
                      .Include(f => f.Escolaridade)
                      .Include(f => f.EstadoCivil)
                      .Include(f => f.Nacionalidade)
                      .Include(f => f.Sexo)
                      .Include(f => f.Terceiro)
                      .Include(f => f.SubGrupoDealers)
                      .Include(f => f.StatusTerceiro)
                      .Include(f => f.Atividade)
                      .Include(f => f.RamoAtividade)
                      .Include(f => f.Empresa)
                      .Include(f => f.RecursosHumanos)
                      .Include(f => f.EstadoPServ)
                      .Include(f => f.SitesCallCenter)
                      .Include(f => f.AndarPredioTel)
                      .Include(f => f.AcessoLogico)
                      .Include(f => f.AcessoFisico)
                      .Include(f => f.GrupoAtendimento)
                      .Include(f => f.DedicadoTelefonica)
                      .Include(f => f.Dependencia)
                      .Include(f => f.ContatoCliente)
                      .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(Guid id)
        {
            return _context.Funcionarios.Any(e => e.Id == id);
        }

        public async Task<IActionResult> GerarExcel(Guid id)
        {
            var funcionario = await _context.Funcionarios
          .Include(f => f.Acao)
          .Include(f => f.Certificado)
          .Include(f => f.Escolaridade)
          .Include(f => f.EstadoCivil)
          .Include(f => f.Nacionalidade)
          .Include(f => f.Sexo)
          .Include(f => f.Terceiro)
          .Include(f => f.SubGrupoDealers)
          .Include(f => f.StatusTerceiro)
          .Include(f => f.Atividade)
          .Include(f => f.RamoAtividade)
          .Include(f => f.Empresa)
          .Include(f => f.RecursosHumanos)
          .Include(f => f.EstadoPServ)
          .Include(f => f.SitesCallCenter)
          .Include(f => f.AndarPredioTel)
          .Include(f => f.AcessoLogico)
          .Include(f => f.AcessoFisico)
          .Include(f => f.GrupoAtendimento)
          .Include(f => f.DedicadoTelefonica)
          .Include(f => f.Dependencia)
          .Include(f => f.ContatoCliente)
          .FirstOrDefaultAsync(m => m.Id == id);


            List<Funcionario> lista = new List<Funcionario>();
            lista.Add(funcionario);

            //Ajuste de dados

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Terceiros");
                var currentRow = 3;
                worksheet.Cell(currentRow, 2 ).Value = "Ação";
                worksheet.Cell(currentRow, 3 ).Value = "Nº de matricula SAP";
                worksheet.Cell(currentRow, 4 ).Value = "Tipo de Terceiro";
                worksheet.Cell(currentRow, 5 ).Value = "Nome";
                worksheet.Cell(currentRow, 6 ).Value = "Sobrenome";
                worksheet.Cell(currentRow, 7 ).Value = "Sexo";
                worksheet.Cell(currentRow, 8 ).Value = "Passaporte";
                worksheet.Cell(currentRow, 9 ).Value = "CPF";
                worksheet.Cell(currentRow, 10).Value = "PIS";
                worksheet.Cell(currentRow, 11).Value = "Estado civil";
                worksheet.Cell(currentRow, 12).Value = "RG";
                worksheet.Cell(currentRow, 13).Value = "Orgão Emissor";
                worksheet.Cell(currentRow, 14).Value = "Data Nascim.";
                worksheet.Cell(currentRow, 15).Value = "Nacionalidade";
                worksheet.Cell(currentRow, 16).Value = "Nº telefone";
                worksheet.Cell(currentRow, 17).Value = "Escolaridade";
                worksheet.Cell(currentRow, 18).Value = "Certificado Escolar";
                worksheet.Cell(currentRow, 19).Value = "Documento de compra";
                worksheet.Cell(currentRow, 20).Value = "Item";
                worksheet.Cell(currentRow, 21).Value = "CNPJ Subcontratada";
                worksheet.Cell(currentRow, 22).Value = "CNPJ";
                worksheet.Cell(currentRow, 23).Value = "Subgrupo Dealers";
                worksheet.Cell(currentRow, 24).Value = "Unidade Gestor Operacional";
                worksheet.Cell(currentRow, 25).Value = "Unidade Gestor Contrato";
                worksheet.Cell(currentRow, 26).Value = "Solicitante";
                worksheet.Cell(currentRow, 27).Value = "Inicio da atividade";
                worksheet.Cell(currentRow, 28).Value = "Fim da atividade";
                worksheet.Cell(currentRow, 29).Value = "Status do Terceiro";
                worksheet.Cell(currentRow, 30).Value = "Atividade";
                worksheet.Cell(currentRow, 31).Value = "Ramo de atividade";
                worksheet.Cell(currentRow, 32).Value = "Empresa";
                worksheet.Cell(currentRow, 33).Value = "Área rec.hum.";
                worksheet.Cell(currentRow, 34).Value = "Subárea";
                worksheet.Cell(currentRow, 35).Value = "Cidade de prestação de serviço";
                worksheet.Cell(currentRow, 36).Value = "Estado de prestação de Serviço";
                worksheet.Cell(currentRow, 37).Value = "Sites Call Center";
                worksheet.Cell(currentRow, 38).Value = "Andar do Prédio Telefonica";
                worksheet.Cell(currentRow, 39).Value = "Acesso Lógico";
                worksheet.Cell(currentRow, 40).Value = "Acesso Físico";
                worksheet.Cell(currentRow, 41).Value = "Grupo de Atendimento";
                worksheet.Cell(currentRow, 42).Value = "Prorroga";
                worksheet.Cell(currentRow, 43).Value = "Dependências";
                worksheet.Cell(currentRow, 44).Value = "IMEI";
                worksheet.Cell(currentRow, 45).Value = "Contato com cliente";
                worksheet.Cell(currentRow, 46).Value = "Serviço Dedicado Apenas para Telefonica";
                worksheet.Columns(2, 46).AdjustToContents();

                foreach (var user in lista)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 2 ).Value = user.Acao.Opcoes;
                    worksheet.Cell(currentRow, 3 ).Value = user.Matricula;
                    worksheet.Cell(currentRow, 4 ).Value = user.Terceiro.Opcoes;
                    worksheet.Cell(currentRow, 5 ).Value = user.Nome;
                    worksheet.Cell(currentRow, 6 ).Value = user.SobreNome;
                    worksheet.Cell(currentRow, 7 ).Value = user.Sexo.Opcoes;
                    worksheet.Cell(currentRow, 8 ).Value = user.Passaporte;
                    worksheet.Cell(currentRow, 9 ).Value = user.CPF;
                    worksheet.Cell(currentRow, 10).Value = user.PIS;
                    worksheet.Cell(currentRow, 11).Value = user.EstadoCivil.Opcoes;
                    worksheet.Cell(currentRow, 12).Value = user.RG;
                    worksheet.Cell(currentRow, 13).Value = user.OrgaoEmissor;
                    worksheet.Cell(currentRow, 14).Value = ConverterData(user.DataNascimento);
                    worksheet.Cell(currentRow, 15).Value = user.Nacionalidade.Opcoes;
                    worksheet.Cell(currentRow, 16).Value = user.Telefone;
                    worksheet.Cell(currentRow, 17).Value = user.Escolaridade.Opcoes;
                    worksheet.Cell(currentRow, 18).Value = user.Certificado.Opcoes;
                    worksheet.Cell(currentRow, 19).Value = user.DocumentoCompra;
                    worksheet.Cell(currentRow, 20).Style.NumberFormat.Format = "00000";
                    worksheet.Cell(currentRow, 20).Value = user.Item;
                    worksheet.Cell(currentRow, 21).Value = user.SubContratada;
                    worksheet.Cell(currentRow, 21).Style.NumberFormat.Format = "00000000000000";
                    worksheet.Cell(currentRow, 22).Value = user.CNPJ;
                    worksheet.Cell(currentRow, 22).Style.NumberFormat.Format = "00000000000000";
                    worksheet.Cell(currentRow, 23).Value = user.SubGrupoDealers.Opcoes == "0 Nenhum" ? "" : user.SubGrupoDealers.Opcoes; 
                    worksheet.Cell(currentRow, 24).Value = user.UnidadeGestorOperacional;
                    worksheet.Cell(currentRow, 25).Value = user.UnidadeGestorContrato;
                    worksheet.Cell(currentRow, 26).Value = user.Solicitante;
                    worksheet.Cell(currentRow, 27).Value = ConverterData(user.InicioAtividade);
                    worksheet.Cell(currentRow, 28).Value = ConverterData(user.FimAtividade);
                    worksheet.Cell(currentRow, 29).Value = user.StatusTerceiro.Opcoes;
                    worksheet.Cell(currentRow, 30).Value = user.Atividade.Opcoes;
                    worksheet.Cell(currentRow, 31).Value = user.RamoAtividade.Opcoes;
                    worksheet.Cell(currentRow, 32).Value = user.Empresa.Opcoes;
                    worksheet.Cell(currentRow, 33).Value = user.RecursosHumanos.Opcoes;
                    worksheet.Cell(currentRow, 34).Style.NumberFormat.Format = "0000";
                    worksheet.Cell(currentRow, 34).Value = user.SubArea;

                    if(user.Dependencia.Opcoes == "1 Trabalha dentro dos prédios da Telefônica")
                    {
                        //cidade prestação e estado prestação
                        worksheet.Cell(currentRow, 35).Value = "";
                        worksheet.Cell(currentRow, 36).Value = "";

                    }else
                    {
                        worksheet.Cell(currentRow, 35).Value = user.CidadePServ;
                        worksheet.Cell(currentRow, 36).Value = user.EstadoPServ.Opcoes;
                    }
    
                    worksheet.Cell(currentRow, 37).Value = user.SitesCallCenter.Opcoes == "0 Nenhum" ? "" : user.SitesCallCenter.Opcoes;
                    worksheet.Cell(currentRow, 38).Value = user.AndarPredioTel.Opcoes;
                    worksheet.Cell(currentRow, 39).Value = user.AcessoLogico.Opcoes;
                    worksheet.Cell(currentRow, 40).Value = user.AcessoFisico.Opcoes;
                    worksheet.Cell(currentRow, 41).Value = user.GrupoAtendimento.Opcoes;
                    worksheet.Cell(currentRow, 42).Value = user.Prorroga;
                    worksheet.Cell(currentRow, 43).Value = user.Dependencia.Opcoes;
                    worksheet.Cell(currentRow, 44).Value = "";
                    worksheet.Cell(currentRow, 45).Value = user.ContatoCliente.Opcoes;
                    worksheet.Cell(currentRow, 46).Value = user.DedicadoTelefonica.Opcoes;
                    worksheet.Columns(2, 46).AdjustToContents();
                  
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();                 

                   return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Arquivo_Carga.xlsx");
                }

            }
        }

        public string ConverterData(string data)
        {
             //01 2 34 5 6789
             //28 / 12 / 1985
            var c = data.ToCharArray(0,10);
            var dataConvert = $"{c[6]}{c[7]}{c[8]}{c[9]}{c[3]}{c[4]}{c[0]}{c[1]}";
            
            return dataConvert;
        }
    }
}
