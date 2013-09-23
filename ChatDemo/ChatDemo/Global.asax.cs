using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using ChatDemo.Ioc;
using Microsoft.AspNet.SignalR.Hubs;
using IDependencyResolver = Microsoft.AspNet.SignalR.IDependencyResolver;

namespace ChatDemo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        private static IWindsorContainer _container;

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            BootstrapContainer();
            // SignalR
            _container.Register(Classes.FromThisAssembly().BasedOn(typeof(IHub)).LifestyleTransient());
            var signalRDependencyResolver = new SignalRDependencyResolver(_container);
            Microsoft.AspNet.SignalR.GlobalHost.DependencyResolver = signalRDependencyResolver;
            RouteTable.Routes.MapHubs();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}