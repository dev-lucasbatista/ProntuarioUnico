using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProntuarioUnico.AuxiliaryClasses.ActionResult
{
    public class StatusRedirectResult : RedirectToRouteResult
    {
        private HttpStatusCode Status { get; set; }

        public StatusRedirectResult(RouteValueDictionary routeValues, HttpStatusCode statusCode) : base(routeValues)
        {
            this.Status = statusCode;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = Convert.ToInt32(Status);
            base.ExecuteResult(context);
        }
    }
}