using ProntuarioUnico.Business.Entities.Enums;
using System;
using System.Web;
using System.Web.Security;

namespace ProntuarioUnico.AuxiliaryClasses
{
    public static class UserAuthentication
    {
        public static StatusLogin LoginPessoaFisica(string login, long codigoInterno, string nome)
        {
            FormsAuthentication.SetAuthCookie(login, true);
            HttpContext.Current.Session["usuario"] = login;
            HttpContext.Current.Session["tipo_usuario"] = "pessoa_fisica";
            HttpContext.Current.Session["nome"] = nome;
            HttpContext.Current.Session["codigo_identificacao"] = Convert.ToString(codigoInterno);

            return StatusLogin.Sucesso;
        }

        public static StatusLogin LoginMedico(string login, long codigoInterno, string nome)
        {
            FormsAuthentication.SetAuthCookie(login, true);
            HttpContext.Current.Session["usuario"] = login;
            HttpContext.Current.Session["tipo_usuario"] = "medico";
            HttpContext.Current.Session["nome"] = nome;
            HttpContext.Current.Session["codigo_identificacao"] = Convert.ToString(codigoInterno);

            return StatusLogin.Sucesso;
        }

        public static StatusLogin Logoff()
        {
            HttpContext.Current.Session.Clear();
            FormsAuthentication.SignOut();

            return StatusLogin.Out;
        }

        public static string ObterCodigoInternoUsuarioLogado()
        {
            return Convert.ToString(HttpContext.Current.Session["codigo_identificacao"]);
        }

        public static string ObterTipoUsuario()
        {
            return Convert.ToString(HttpContext.Current.Session["tipo_usuario"]);
        }

        public static string ObterNome()
        {
            return Convert.ToString(HttpContext.Current.Session["nome"]);
        }
    }
}