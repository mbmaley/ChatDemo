using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Castle.Core.Logging;
using ChatDemo.ViewModels.Chat;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatDemo;
using ChatDemo.Controllers;
using MvcContrib.TestHelper;
using MvcContrib.TestHelper.Fakes;

namespace ChatDemo.Tests.Controllers
{
    [TestClass]
    public class ChatControllerTest
    {
        [TestMethod]
        public void SimpleChat_CheckControllerContainsSimpleChat_SimpleChatIsFound()
        {
            // Arrange
            ChatController controller = new ChatController();
            controller.Logger = NullLogger.Instance;
            // Act
            ViewResult result = controller.SimpleChat() as ViewResult;

            // Assert
           Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SimpleChat_AuthenticatedUserPopulatesViewModel_ViewModelIsPopulated()
        {
            // Arrange
            var controller = new ChatController();
            controller.Logger = NullLogger.Instance;
            var builder = new TestControllerBuilder();
            builder.HttpContext.User = new FakePrincipal(new FakeIdentity("Michael"), new string[] { "Role" });
            builder.InitializeController(controller);

            // Act
            ViewResult result = controller.SimpleChat() as ViewResult;
            var chatViewModel = (SimpleViewModel)result.ViewData.Model;

            // Assert
            Assert.AreEqual("Michael", chatViewModel.Nickname);
        }
    }
}
