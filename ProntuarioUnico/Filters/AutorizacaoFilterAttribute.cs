using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ProntuarioUnico.AuxiliaryClasses.ActionResult;

namespace ProntuarioUnico.Filters
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionAtiva())
            {
                // ADICIONA EVENTO DE ESCONDER BOTÃO NA PÁGINA DE MENUS.
                filterContext.Controller.ViewBag.TipoUsuario = this.ObterTipoUsuario();
                filterContext.Controller.ViewBag.Nome = this.ObterNome();
            }
            else
            {
                filterContext.Result = new StatusRedirectResult(
                    new RouteValueDictionary
                    {
                            {
                                "controller", "Login"
                            },
                            {
                                "action", "Login"
                            }
                    },
                    HttpStatusCode.Unauthorized
                );
            }
        }

        private bool SessionAtiva()
        {
            string usuario = Convert.ToString(HttpContext.Current.Session["usuario"]);
            return !string.IsNullOrEmpty(usuario);
        }

        private string ObterTipoUsuario()
        {
            return Convert.ToString(HttpContext.Current.Session["tipo_usuario"]);
        }

        private string ObterNome()
        {
            return Convert.ToString(HttpContext.Current.Session["nome"]);
        }
    }
}
