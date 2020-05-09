using ProntuarioUnico.Injection;
using ProntuarioUnico.Mappers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProntuarioUnico
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InjectionDependency.Register();
            AutoMapperConfig.RegisterMappings();
        }
    }
}
