using ProntuarioUnico.Business.Business;
using ProntuarioUnico.Business.Interfaces.Business;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Data.Repository;
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
            container.Register<IPessoaFisicaBusiness, PessoaFisicaBusiness>(Lifestyle.Scoped);

            // Data
            container.Register<IPessoaFisicaRepository, PessoaFisicaRepository>(Lifestyle.Scoped);
            container.Register<IProntuarioRepository, ProntuarioRepository>(Lifestyle.Scoped);
            container.Register<IEspecialidadeAtendimentoRepository, EspecialidadeAtendimentoRepository>(Lifestyle.Scoped);
            container.Register<IAtendimentoRepository, AtendimentoRepository>(Lifestyle.Scoped);
            container.Register<IMedicoRepository, MedicoRepository>(Lifestyle.Scoped);
            container.Register<ITokenAtendimentoRepository, TokenAtendimentoRepository>(Lifestyle.Scoped);
            container.Register<ITipoAtendimentoRepository, TipoAtendimentoRepository>(Lifestyle.Scoped);


            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
