using System.Web.Http.Controllers;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WindsorWebApi.Controllers;

namespace WindsorWebApi.WindsorInstallers
{
    public class WebApiControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<AboutController>()
                                       .BasedOn<IHttpController>()
                                       .LifestylePerWebRequest());
        }
    }
}