using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace ABCP.Web.Services
{
    public class WindsorHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;

        public WindsorHttpControllerActivator(IWindsorContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request,
                                      HttpControllerDescriptor controllerDescriptor,
                                      Type controllerType)
        {
            try
            {
                var controller = (IHttpController)_container.Resolve(controllerType);
                request.RegisterForDispose(new Release(() => _container.Release(controller)));
                return controller;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(string.Format("Error resolving type [{0}].", controllerType.Name), ex);
            }
        }

        private class Release : IDisposable
        {
            private readonly Action _release;
            public Release(Action release)
            {
                _release = release;
            }

            public void Dispose()
            {
                _release();
            }
        }
    }
}