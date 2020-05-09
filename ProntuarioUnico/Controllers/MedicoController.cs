using AutoMapper;
using ProntuarioUnico.AuxiliaryClasses;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Filters;
using ProntuarioUnico.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProntuarioUnico.Controllers
{
    [AutorizacaoFilter]
    public class MedicoController : Controller
    {
        private readonly IMedicoRepository MedicoRepository;

        public MedicoController(IMedicoRepository medicoRepository)
        {
            this.MedicoRepository = medicoRepository;
            ViewBag.NomePagina = "Informações do Médico";
        }

        // GET: Medico
        public ActionResult Index()
        {
            string codigo = UserAuthentication.ObterCodigoInternoUsuarioLogado();

            Medico medico = this.MedicoRepository.Obter(Convert.ToInt32(codigo));
            MedicoViewModel viewModel = Mapper.Map<Medico, MedicoViewModel>(medico);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Atualizar(MedicoViewModel medicoViewModel)
        {
            if (medicoViewModel.Valido())
            {
                Medico medico = this.MedicoRepository.Obter(Convert.ToInt32(medicoViewModel.Codigo));
                Medico medicoAtualizado = Mapper.Map<MedicoViewModel, Medico>(medicoViewModel);

                if (medico.CRM == medicoViewModel.CRM || !this.MedicoRepository.CRMExistente(medicoViewModel.CRM))
                {
                    if (medicoViewModel.AlterarSenha)
                    {
                        String senhaBase64 = Utils.Base64Encode(medicoViewModel.SenhaAntiga);

                        if (senhaBase64.Equals(medico.Senha))
                        {
                            medicoAtualizado.Senha = Utils.Base64Encode(medicoViewModel.NovaSenha);
                        }
                    }

                    this.MedicoRepository.Alterar(medicoAtualizado);
                }
                else
                {
                    return Json("CRM já foi cadastrado por um outro médico.");
                }
            }

            return RedirectToAction("Index", "Medico");
        }
    }
}