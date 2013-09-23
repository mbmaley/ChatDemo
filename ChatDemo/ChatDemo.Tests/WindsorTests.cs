using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
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
        public void Windsor_Can_Resolve_HomeController_Dependencies()
        {
            // Arrange
            var container = new WindsorContainer();
            container.Install(FromAssembly.Named("ChatDemo"));

            // Act
            var controller = container.Resolve<HomeController>();

            //Assert

            Assert.IsInstanceOfType(controller,typeof(IController));
        }

    }
}
