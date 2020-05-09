using System;
using System.Web.Mvc;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.ViewModels.Login;
using ProntuarioUnico.AuxiliaryClasses;
using AutoMapper;

namespace ProntuarioUnico.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPessoaFisicaRepository PessoaFisicaRepository;
        private readonly IMedicoRepository MedicoRepository;
        private Global mobjGlobal = new Global();

        public LoginController(IPessoaFisicaRepository pessoaFisicaRepository, IMedicoRepository medicoRepository)
        {
            this.PessoaFisicaRepository = pessoaFisicaRepository;
            this.MedicoRepository = medicoRepository;
        }

        // GET: Login
        public ActionResult Login()
        {
            UserAuthentication.Logoff();

            ViewBag.Usuario = new LoginViewModel();
            ViewBag.NovoUsuario = new NovoUsuarioPessoaFisicaViewModel();

            return View();
        }

        [HttpPost]
        public JsonResult AutenticaPessoa(String vstrCPF, String vstrSenha)
        {
            //Retorno
            object lobjException = null;
            bool lblnRetorno = false;
            //Objetos
            Exception lexcMensagem = null;
            // Auxiliar
            
            try
            {
                if( !String.IsNullOrEmpty(vstrCPF) && !String.IsNullOrWhiteSpace(vstrCPF) &&
                    !String.IsNullOrEmpty(vstrSenha) && !String.IsNullOrWhiteSpace(vstrSenha))
                {
                    PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(vstrCPF);

                    if (pessoa != default(PessoaFisica))
                    {
                        String senhaBase64 = Utils.Base64Encode(vstrSenha);

                        if (pessoa.Senha.Equals(senhaBase64))
                        {
                            UserAuthentication.LoginPessoaFisica(vstrCPF, pessoa.Codigo, pessoa.Nome);
                            lblnRetorno = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (lexcMensagem == null) { lexcMensagem = ex; }
            }
            finally
            {
                if (lexcMensagem != null)
                {
                    lobjException = mobjGlobal.ConverterParaJson(mobjGlobal.CriarException(lexcMensagem, lexcMensagem.Message));
                    lexcMensagem = null;
                }
            }
            return Json(
                new
                {
                    Exception = lobjException,
                    Retorno = lblnRetorno
                },
                "json"
            );
        }

        [HttpPost]
        public ActionResult Logar(LoginViewModel usuario)
        {
            //if (usuario.Valido())
            //{
            //    PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(usuario.CPF);

            //    if (pessoa != default(PessoaFisica))
            //    {
            //        String senhaBase64 = Utils.Base64Encode(usuario.Senha);

            //        if (pessoa.Senha.Equals(senhaBase64))
            //        {
            //            UserAuthentication.Login(usuario.CPF, pessoa.Codigo);

            //            return RedirectToAction("Index", "PessoaFisica");
            //        }
            //    }
            //}

            //return Json("CPF ou senha inválidos.");
            return RedirectToAction("Index", "Prontuario");
        }

        [HttpPost]
        public JsonResult AutenticarCadastroPF(NovoUsuarioPessoaFisicaViewModel novoUsuario)
        {
            //Retorno
            object lobjException = null;
            object lobjRetorno = null;
            //Objetos
            Exception lexcMensagem = null;
            // Auxiliar
            string lstrMsg = "";
            bool lblnRetorno = false;

            try
            {
                if (novoUsuario.Valido())
                {
                    if (Utils.CPFValido(novoUsuario.CPF))
                    {
                        if (!this.PessoaFisicaRepository.CPFExistente(novoUsuario.CPF.Trim().Replace(".", "").Replace("-", "")))
                        {
                            PessoaFisica novaPessoaFisica = Mapper.Map<NovoUsuarioPessoaFisicaViewModel, PessoaFisica>(novoUsuario);
                            novaPessoaFisica.CPF = novaPessoaFisica.CPF.Trim().Replace(".", "").Replace("-", "");
                            novaPessoaFisica.Senha = Utils.Base64Encode(novaPessoaFisica.Senha);

                            this.PessoaFisicaRepository.Cadastrar(novaPessoaFisica);

                            lstrMsg = "Pessoa cadastrada com sucesso!";
                            lblnRetorno = true;
                        }
                        else
                        {
                            lstrMsg = "Já existe uma pessoa cadastrada com o CPF informado.";
                        }
                    }
                    else
                    {
                        lstrMsg = "CPF inválido.";
                    }
                }
                else
                {
                    lstrMsg = "Existem campos obrigatórios que não foram cadastrados.";
                }
            }
            catch (Exception ex)
            {
                if (lexcMensagem == null) { lexcMensagem = ex; }
            }
            finally
            {
                if (lexcMensagem != null)
                {
                    lobjException = mobjGlobal.ConverterParaJson(mobjGlobal.CriarException(lexcMensagem, lexcMensagem.Message));
                    lexcMensagem = null;
                }
            }

            
            lobjRetorno = new
            {
                Mensagem = lstrMsg,
                Cadastro = lblnRetorno
            };

            return Json(
                new
                {
                    Exception = lobjException,
                    Retorno = lobjRetorno
                },
                "json"
            );
        }

        [HttpPost]
        public JsonResult AutenticarRecuperarAcessoPessoaFisica(String cpf)
        {
            //Retorno
            object lobjException = null;
            //Objetos
            Exception lexcMensagem = null;
            // Auxiliar
            string lstrMsg = "";
            bool lblnRetorno = false;
            try
            {
                if (!String.IsNullOrEmpty(cpf) && !String.IsNullOrWhiteSpace(cpf) && Utils.CPFValido(cpf))
                {
                    PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(cpf);

                    if (pessoa == default(PessoaFisica))
                        lstrMsg = "CPF informado não encontrado.";

                    string codigo = Utils.GenerateRandomNumber();
                    string codigoBase64 = Utils.Base64Encode(codigo);

                    pessoa.Senha = codigoBase64;
                    this.PessoaFisicaRepository.Alterar(pessoa);

                    Utils.SendEmail(pessoa.Email, $"Olá, {pessoa.Nome}. Foi realizada a alteração da sua senha anterior. A nova senha é : {codigo}. Você pode realizar o login e alterar sua senha a área de cadastro.", "Recuperação de Senha - Nova senha gerada");

                    lblnRetorno = true;
                    lstrMsg = String.Format("Olá, {0}. Foi realizada a alteração da sua senha anterior, acesse o e-mail cadastrado para mais informações!", pessoa.Nome);
                }
                else
                {
                    lstrMsg = "CPF inválido";
                }
            }
            catch (Exception ex)
            {
                if (lexcMensagem == null) { lexcMensagem = ex; }
            }
            finally
            {
                if (lexcMensagem != null)
                {
                    lobjException = mobjGlobal.ConverterParaJson(mobjGlobal.CriarException(lexcMensagem, lexcMensagem.Message));
                    lexcMensagem = null;
                }
            }
            return Json(
                new
                {
                    Exception = lobjException,
                    Retorno = new
                    {
                        Mensagem = lstrMsg,
                        Cadastro = lblnRetorno
                    }
                },
                "json"
            );
        }

        [HttpPost]
        public JsonResult AutenticarRecuperarAcessoMedico(String crm)
        {
            //Retorno
            object lobjException = null;
            //Objetos
            Exception lexcMensagem = null;
            // Auxiliar
            string lstrMsg = "";
            bool lblnRetorno = false;
            try
            {
                if (!String.IsNullOrEmpty(crm) && !String.IsNullOrWhiteSpace(crm))
                {
                    Medico medico = this.MedicoRepository.Obter(crm);

                    if (medico == default(Medico))
                        lstrMsg = "CRM informado não encontrado.";

                    string codigo = Utils.GenerateRandomNumber();
                    string codigoBase64 = Utils.Base64Encode(codigo);

                    medico.Senha = codigoBase64;
                    this.MedicoRepository.Alterar(medico);

                    Utils.SendEmail(medico.Email, $"Olá, {medico.NomeGuerra}. Foi realizada a alteração da sua senha anterior. A nova senha é : {codigo}. Você pode realizar o login e alterar sua senha a área de cadastro.", "Recuperação de Senha - Nova senha gerada");

                    lblnRetorno = true;
                    lstrMsg = String.Format("Olá, {0}. Foi realizada a alteração da sua senha anterior, acesse o e-mail cadastrado para mais informações!", medico.NomeGuerra);
                }
                else
                {
                    lstrMsg = "CRM inválido";
                }
            }
            catch (Exception ex)
            {
                if (lexcMensagem == null) { lexcMensagem = ex; }
            }
            finally
            {
                if (lexcMensagem != null)
                {
                    lobjException = mobjGlobal.ConverterParaJson(mobjGlobal.CriarException(lexcMensagem, lexcMensagem.Message));
                    lexcMensagem = null;
                }
            }
            return Json(
                new
                {
                    Exception = lobjException,
                    Retorno = new
                    {
                        Mensagem = lstrMsg,
                        Cadastro = lblnRetorno
                    }
                },
                "json"
            );
        }

        [HttpPost]
        public JsonResult AutenticaMedico(String vstrCRM, String vstrSenha)
        {
            //Retorno
            object lobjException = null;
            bool lblnRetorno = false;
            //Objetos
            Exception lexcMensagem = null;
            // Auxiliar

            try
            {
                if (!String.IsNullOrEmpty(vstrCRM) && !String.IsNullOrWhiteSpace(vstrCRM) &&
                    !String.IsNullOrEmpty(vstrSenha) && !String.IsNullOrWhiteSpace(vstrSenha))
                {
                    Medico medico = this.MedicoRepository.Obter(vstrCRM);

                    if (medico != default(Medico))
                    {
                        String senhaBase64 = Utils.Base64Encode(vstrSenha);

                        if (medico.Senha.Equals(senhaBase64))
                        {
                            UserAuthentication.LoginMedico(vstrCRM, medico.Codigo, medico.NomeGuerra);
                            lblnRetorno = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (lexcMensagem == null) { lexcMensagem = ex; }
            }
            finally
            {
                if (lexcMensagem != null)
                {
                    lobjException = mobjGlobal.ConverterParaJson(mobjGlobal.CriarException(lexcMensagem, lexcMensagem.Message));
                    lexcMensagem = null;
                }
            }
            return Json(
                new
                {
                    Exception = lobjException,
                    Retorno = lblnRetorno
                },
                "json"
            );
        }

        [HttpPost]
        public ActionResult LogarMedico(LoginViewModel usuario)
        {
            //if (usuario.Valido())
            //{
            //    Medico medico = this.MedicoRepository.Obter(usuario.CPF);

            //    if (medico != default(Medico))
            //    {
            //        String senhaBase64 = Utils.Base64Encode(usuario.Senha);

            //        if (medico.Senha.Equals(senhaBase64))
            //        {
            //            UserAuthentication.Login(usuario.CPF, medico.Codigo);

            //            return RedirectToAction("Index", "Medico");
            //        }
            //    }
            //}

            //return Json("CRM ou senha inválidos.");
            return RedirectToAction("Index", "Atendimento");
        }

        [HttpPost]
        public ActionResult RecuperarAcessoMedico(String crm)
        {
            Medico medico = this.MedicoRepository.Obter(crm);

            if (medico == default(Medico))
                return Json("CRM informado não encontrado.");

            string codigo = Utils.GenerateRandomNumber();
            string codigoBase64 = Utils.Base64Encode(codigo);

            medico.Senha = codigoBase64;
            this.MedicoRepository.Alterar(medico);

            Utils.SendEmail(medico.Email, $"Olá, {medico.NomeGuerra}. Foi realizada a alteração da sua senha anterior. A nova senha é : {codigo}. Você pode realizar o login e alterar sua senha a área de cadastro.", "Recuperação de Senha - Nova senha gerada");

            return RedirectToAction("Login", "Login");
        }
    }
}