using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Castle.Core.Logging;
using ChatDemo.ViewModels.Chat;

namespace ChatDemo.Controllers
{
    public class ChatController : Controller
    {
        public ILogger Logger { get; set; }

        public ActionResult SimpleChat()
        {
            Logger.Info("Starting the simple chat page.");

            if (User != null && User.Identity.IsAuthenticated)
            {
                var simpleChat = new SimpleViewModel
                                     {
                                         Nickname = User.Identity.Name
                                     };
                return View(simpleChat);
            }

            return View();
        }

    }
}
