using ProntuarioUnico.AuxiliaryClasses;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Filters;
using ProntuarioUnico.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProntuarioUnico.Controllers
{
    [AutorizacaoFilter]
    public class HomeController : Controller
    {
        private readonly IPessoaFisicaRepository PessoaFisicaRepository;
        private readonly IMedicoRepository MedicoRepository;

        public HomeController(IPessoaFisicaRepository pessoaFisicaRepository, IMedicoRepository medicoRepository)
        {
            this.PessoaFisicaRepository = pessoaFisicaRepository;
            this.MedicoRepository = medicoRepository;
        }

        public ActionResult Index()
        {
            string codigo = UserAuthentication.ObterCodigoInternoUsuarioLogado();
            string tipoUsuario = UserAuthentication.ObterTipoUsuario();

            if (tipoUsuario == "pessoa_fisica")
            {
                PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(Convert.ToInt32(codigo));

                ViewBag.NomeUsuario = pessoa.Nome;
                ViewBag.NomePagina = $"Olá, {pessoa.Nome}";
            }
            else
            {
                Medico medico = this.MedicoRepository.Obter(Convert.ToInt32(codigo));

                ViewBag.NomePagina = $"Olá, {medico.NomeGuerra}";
            }

            return View();
        }
    }
}