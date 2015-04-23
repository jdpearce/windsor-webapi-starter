using System.Web.Http;
using System.Web.Http.Dispatcher;
using ABCP.Web.Services;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using WindsorWebApi.Services;
using WindsorWebApi.WindsorInstallers;

namespace WindsorWebApi
{
    public class WindsorConfig
    {
        public static IWindsorContainer Container { get; private set; }

        public static void RegisterContainer()
        {
            Container = new WindsorContainer().Install(FromAssembly.InThisApplication());
            Container.Kernel.Resolver.AddSubResolver(new AppSettingsConvention());
            Container.Register(Component.For<IWindsorContainer>().Instance(Container));
            Container.AddFacility<LoggingFacility>(f => f.UseLog4Net());
            Container.Register(Component.For<ICustomRoleProvider>().ImplementedBy<CustomRoleProvider>().LifestyleTransient());
            Container.Register(Component.For<IHttpControllerActivator>().Instance(new WindsorHttpControllerActivator(Container)));

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), Container.Resolve<IHttpControllerActivator>());
        }

        public static void DisposeContainer()
        {
            if (Container != null)
                Container.Dispose();
        }
    }
}