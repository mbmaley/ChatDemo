using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using ChatDemo.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChatDemo.Tests
{
    [TestClass]
    public class WindsorTests
    {

        [TestMethod]
        public void WindsorCanResolveHomeControllerDependencies_HomeControllerResolved()
        {
            // Arrange
            var container = new WindsorContainer();
          
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Null));
            container.Register(Classes.FromAssemblyNamed("ChatDemo")
                    .BasedOn<IController>()
                    .LifestyleTransient());
            // Act
            var controller = container.Resolve<HomeController>();

            //Assert

            Assert.IsInstanceOfType(controller,typeof(IController));
        }

        [TestMethod]
        [ExpectedException(typeof(ComponentNotFoundException))]
        public void WindsorCanNotResolveHomeControllerDependencies_ComponentNotFoundExceptionThrown()
        {
            // Arrange
            var container = new WindsorContainer();

            // Act
            var controller = container.Resolve<HomeController>();

            //Assert

            // Exception should be thrown
        }

    }
}
