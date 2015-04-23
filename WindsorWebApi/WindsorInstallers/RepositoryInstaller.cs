using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WindsorWebApi.Storage;

namespace WindsorWebApi.WindsorInstallers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITodoItemRepository>().ImplementedBy<TodoItemRepository>()
                                        .LifestyleSingleton());
        }
    }
}