using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace ChatDemo.Ioc
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            this._kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)_kernel.Resolve(controllerType);
        }

    }
}
