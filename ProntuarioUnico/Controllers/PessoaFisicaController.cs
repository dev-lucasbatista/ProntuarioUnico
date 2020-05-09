using AutoMapper;
using ProntuarioUnico.AuxiliaryClasses;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Filters;
using ProntuarioUnico.ViewModels;
using System;
using System.Web.Mvc;

namespace ProntuarioUnico.Controllers
{
    [AutorizacaoFilter]
    public class PessoaFisicaController : Controller
    {
        private readonly IPessoaFisicaRepository PessoaFisicaRepository;
        private readonly IMedicoRepository MedicoRepository;

        public PessoaFisicaController(IPessoaFisicaRepository pessoaFisicaRepository, IMedicoRepository medicoRepository)
        {
            this.PessoaFisicaRepository = pessoaFisicaRepository;
            this.MedicoRepository = medicoRepository;

            CarregarDados();
            ViewBag.NomePagina = "Informações Pessoais do Paciente";
        }

        // GET: PessoaFisica
        public ActionResult Index()
        {
            

            string codigo = UserAuthentication.ObterCodigoInternoUsuarioLogado();

            PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(Convert.ToInt32(codigo));
            PessoaFisicaViewModel viewModel = Mapper.Map<PessoaFisica, PessoaFisicaViewModel>(pessoa);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Atualizar(PessoaFisicaViewModel pessoaViewModel)
        {
            if (pessoaViewModel.Valido())
            {
                PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(Convert.ToInt32(pessoaViewModel.Codigo));
                PessoaFisica pessoaFisicaAtualizada = Mapper.Map<PessoaFisicaViewModel, PessoaFisica>(pessoaViewModel);

                if (pessoaViewModel.AlterarSenha)
                {
                    String senhaBase64 = Utils.Base64Encode(pessoaViewModel.SenhaAntiga);

                    if (senhaBase64.Equals(pessoa.Senha))
                    {
                        pessoaFisicaAtualizada.Senha = Utils.Base64Encode(pessoaViewModel.NovaSenha);
                    }
                }

                this.PessoaFisicaRepository.Alterar(pessoaFisicaAtualizada);

            }

            return RedirectToAction("Index", "PessoaFisica");
        }

        private void CarregarDados()
        {
            string codigo = UserAuthentication.ObterCodigoInternoUsuarioLogado();
            string tipoUsuario = UserAuthentication.ObterTipoUsuario();

            if (tipoUsuario == "pessoa_fisica")
            {
                PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(Convert.ToInt32(codigo));

                ViewBag.TipoUsuario = tipoUsuario;
                ViewBag.NomeUsuario = pessoa.Nome;
            }
            else
            {
                Medico medico = this.MedicoRepository.Obter(Convert.ToInt32(codigo));

                ViewBag.TipoUsuario = tipoUsuario;
                ViewBag.NomeUsuario = medico.NomeGuerra;
            }
        }
    }
}