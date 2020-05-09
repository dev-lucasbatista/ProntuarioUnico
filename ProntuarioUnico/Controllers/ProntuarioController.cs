using AutoMapper;
using Microsoft.Reporting.WebForms;
using ProntuarioUnico.AuxiliaryClasses;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Filters;
using ProntuarioUnico.ViewModels;
using ProntuarioUnico.ViewModels.Filtros;
using ProntuarioUnico.ViewModels.Relatorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProntuarioUnico.Controllers
{
    [AutorizacaoFilter]
    public class ProntuarioController : Controller
    {
        private readonly ITipoAtendimentoRepository TipoAtendimentoRepository;
        private readonly IEspecialidadeAtendimentoRepository EspecialidadeAtendimentoRepository;
        private readonly IProntuarioRepository ProntuarioRepository;
        private readonly IPessoaFisicaRepository PessoaFisicaRepository;
        private readonly IMedicoRepository MedicoRepository;

        public ProntuarioController(IEspecialidadeAtendimentoRepository especialidadeAtendimentoRepository, ITipoAtendimentoRepository tipoAtendimentoRepository, IProntuarioRepository prontuarioRepository,
            IPessoaFisicaRepository pessoaFisicaRepository, IMedicoRepository medicoRepository)
        {
            this.EspecialidadeAtendimentoRepository = especialidadeAtendimentoRepository;
            this.TipoAtendimentoRepository = tipoAtendimentoRepository;
            this.ProntuarioRepository = prontuarioRepository;
            this.PessoaFisicaRepository = pessoaFisicaRepository;
            this.MedicoRepository = medicoRepository;

            ViewBag.NomePagina = $"Consulta de Prontuário - {UserAuthentication.ObterNome()}";
        }

        // GET: Prontuario
        public ActionResult Index(ProntuarioViewModel model)
        {
            ViewBag.TiposAtendimento = this.TipoAtendimentoRepository.ListarAtivos();
            ViewBag.Especialidades = this.EspecialidadeAtendimentoRepository.ListarAtivos();

            return View(model);
        }

        public ActionResult BuscarAtendimentos(FiltroProntuarioViewModel filtro)
        {
            ViewBag.TiposAtendimento = this.TipoAtendimentoRepository.ListarAtivos();
            ViewBag.Especialidades = this.EspecialidadeAtendimentoRepository.ListarAtivos();

            ViewBag.DataInicial = filtro.DataInicial;
            ViewBag.DataFinal = filtro.DataFinal;
            ViewBag.NumeroAtendimento = filtro.NumeroAtendimento;
            ViewBag.CodigoEspecialidade = filtro.CodigoEspecialidade;
            ViewBag.CodigoTipoAtendimento = filtro.CodigoTipoAtendimento;

            if (filtro.Valido())
            {
                List<Prontuario> prontuarios = this.ProntuarioRepository.ListarDetalhado(filtro.DataInicial, filtro.DataFinal, filtro.NumeroAtendimento, filtro.CodigoEspecialidade, filtro.CodigoTipoAtendimento);
                ProntuarioViewModel model = new ProntuarioViewModel(prontuarios);

                return View("Index", model);
            }

            ViewBag.Mensagem = "Intervalo de datas invalido.";
            return View("Index", new ProntuarioViewModel());
        }

        public ActionResult ImprimirPDFCompleto(FiltroProntuarioViewModel filtro)
        {
            if (filtro.Valido())
            {
                List<Prontuario> prontuarios = this.ProntuarioRepository.ListarDetalhado(filtro.DataInicial, filtro.DataFinal, filtro.NumeroAtendimento, filtro.CodigoEspecialidade, filtro.CodigoTipoAtendimento);
                List<AtendimentoPDFView> atendimentos = Mapper.Map<List<Prontuario>, List<AtendimentoPDFView>>(prontuarios);

                LocalReport relatorio = new LocalReport();
                relatorio.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\ReportProntuarioCompleto.rdlc";
                relatorio.DataSources.Add(new ReportDataSource("Prontuario", atendimentos));

                //parametros
                relatorio.SetParameters(new ReportParameter("DataImpressao", DateTime.Now.ToString("dd/MM/yyyy")));
                relatorio.SetParameters(new ReportParameter("Nome", UserAuthentication.ObterNome()));
                relatorio.SetParameters(new ReportParameter("Periodo", $"{filtro.DataInicial.ToString("dd/MM/yyyy")} a {filtro.DataFinal.ToString("dd/MM/yyyy")}"));

                string descricaoTipoAtendimento = "Todos";

                if (filtro.CodigoTipoAtendimento.HasValue)
                {
                    TipoAtendimento tipo = this.TipoAtendimentoRepository.Obter(filtro.CodigoTipoAtendimento.Value);

                    if (!(tipo == default(TipoAtendimento)))
                    {
                        descricaoTipoAtendimento = tipo.DescricaoTipoAtendimento;
                    }
                }

                relatorio.SetParameters(new ReportParameter("Atendimento", descricaoTipoAtendimento));
                string descricaoEspecialidade = "Todos";

                if (filtro.CodigoEspecialidade.HasValue)
                {
                    EspecialidadeAtendimento especialidade = this.EspecialidadeAtendimentoRepository.Obter(filtro.CodigoEspecialidade.Value);

                    if (!(especialidade == default(EspecialidadeAtendimento)))
                    {
                        descricaoEspecialidade = especialidade.DescricaoEspecialidade;
                    }
                }

                return GerarArquivoPDF(relatorio);
            }

            return View("BuscarAtendimentos", filtro);
        }

        public ActionResult ImprimirPDFSimplificado(FiltroProntuarioViewModel filtro)
        {
            if (filtro.Valido())
            {
                List<Prontuario> prontuarios = this.ProntuarioRepository.ListarDetalhado(filtro.DataInicial, filtro.DataFinal, filtro.NumeroAtendimento, filtro.CodigoEspecialidade, null);
                List<EspecialidadeAtendimento> especialidades = this.EspecialidadeAtendimentoRepository.ListarAtivos().Where(_ => filtro.CodigoEspecialidade == null || _.CodigoEspecialidade == filtro.CodigoEspecialidade).ToList();
                List<TipoAtendimento> tipos = this.TipoAtendimentoRepository.ListarAtivos();

                List<AtendimentoSimplificadoPDFViewModel> lista = this.ConverterParaProntuarioSimplificadoViewModel(prontuarios, especialidades, tipos);

                LocalReport relatorio = new LocalReport();
                relatorio.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\ReportProntuarioGeral.rdlc";
                relatorio.DataSources.Add(new ReportDataSource("Prontuario", lista));

                //parametros
                relatorio.SetParameters(new ReportParameter("DataImpressao", DateTime.Now.ToString("dd/MM/yyyy")));
                relatorio.SetParameters(new ReportParameter("Nome", UserAuthentication.ObterNome()));
                relatorio.SetParameters(new ReportParameter("Periodo", $"{filtro.DataInicial.ToString("dd/MM/yyyy")} a {filtro.DataFinal.ToString("dd/MM/yyyy")}"));

                string descricaoTipoAtendimento = "Todos";

                if (filtro.CodigoTipoAtendimento.HasValue)
                {
                    TipoAtendimento tipo = this.TipoAtendimentoRepository.Obter(filtro.CodigoTipoAtendimento.Value);

                    if (!(tipo == default(TipoAtendimento)))
                    {
                        descricaoTipoAtendimento = tipo.DescricaoTipoAtendimento;
                    }
                }

                relatorio.SetParameters(new ReportParameter("Atendimento", descricaoTipoAtendimento));
                string descricaoEspecialidade = "Todos";

                if (filtro.CodigoEspecialidade.HasValue)
                {
                    EspecialidadeAtendimento especialidade = this.EspecialidadeAtendimentoRepository.Obter(filtro.CodigoEspecialidade.Value);

                    if (!(especialidade == default(EspecialidadeAtendimento)))
                    {
                        descricaoEspecialidade = especialidade.DescricaoEspecialidade;
                    }
                }

                relatorio.SetParameters(new ReportParameter("Especialidade", descricaoEspecialidade));

                return GerarArquivoPDF(relatorio);
            }

            return View("BuscarAtendimentos", filtro);
        }

        private FileContentResult GerarArquivoPDF(LocalReport relatorio)
        {
            String reportType = "PDF";
            String mimeType;
            String encoding;
            String fileNameExtension;
            String deviceInfo;
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            deviceInfo = "<DeviceInfo>" + "  <OutputFormat>" + reportType + "</OutputFormat>" + "</DeviceInfo>";

            renderedBytes = relatorio.Render(
            reportType,
            deviceInfo,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings);

            return File(renderedBytes, mimeType);
        }

        private List<AtendimentoSimplificadoPDFViewModel> ConverterParaProntuarioSimplificadoViewModel(List<Prontuario> prontuarios, List<EspecialidadeAtendimento> especialidades, List<TipoAtendimento> tipos)
        {
            List<AtendimentoSimplificadoPDFViewModel> models = new List<AtendimentoSimplificadoPDFViewModel>();

            foreach(EspecialidadeAtendimento especialidade in especialidades)
            {
                AtendimentoSimplificadoPDFViewModel atendimentoEspecialidade = new AtendimentoSimplificadoPDFViewModel();
                atendimentoEspecialidade.Especialidade = especialidade.DescricaoEspecialidade;
                atendimentoEspecialidade.TotalConsulta = Convert.ToString(prontuarios.Count(_ => _.CodigoEspecialidade == especialidade.CodigoEspecialidade && _.CodigoTipoAtendimento == 1));
                atendimentoEspecialidade.TotalExame = Convert.ToString(prontuarios.Count(_ => _.CodigoEspecialidade == especialidade.CodigoEspecialidade && _.CodigoTipoAtendimento == 2)); 
                atendimentoEspecialidade.TotalCirurgia = Convert.ToString(prontuarios.Count(_ => _.CodigoEspecialidade == especialidade.CodigoEspecialidade && _.CodigoTipoAtendimento == 3));
                atendimentoEspecialidade.TotalEspecialidade = Convert.ToString(prontuarios.Count(_ => _.CodigoEspecialidade == especialidade.CodigoEspecialidade));

                models.Add(atendimentoEspecialidade);
            }

            return models.OrderByDescending(_ => _.TotalEspecialidade).ToList();
        }
    }
}