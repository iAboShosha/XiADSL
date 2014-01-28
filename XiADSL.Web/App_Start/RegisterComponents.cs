using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;

using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using XiADSL.Arc;
using XiADSL.DataAccess._base;
using XiADSL.Models.AccountDomain;

namespace XiADSL.Web.App_Start
{
    public class RegisterComponents
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            
            builder.RegisterAssemblyTypes(typeof(IContext).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(BaseContext<>).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(Role).Assembly).AsImplementedInterfaces();
            
            

            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(EFQueryRepository<>)).As(typeof(IQueryRepository<>));
            builder.RegisterType(typeof(SessionManager)).As(typeof(ISessionManager)).SingleInstance();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}