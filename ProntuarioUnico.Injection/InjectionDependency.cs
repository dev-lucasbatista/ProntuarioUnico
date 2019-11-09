using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProntuarioUnico.Injection
{
    public static class InjectionDependency
    {
        public static void Register()
        {
            Container container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Business
            //container.Register<IFormularioBusiness, FormularioBusiness>(Lifestyle.Scoped);

            // Data
            //container.Register<IEpisodioData, EpisodioData>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
