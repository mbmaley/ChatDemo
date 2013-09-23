using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace ChatDemo.Hubs
{
    public class ChatHub : Hub
    {
        /// <summary>
        /// Broadcast the message to all clients.
        /// </summary>
        /// <param name="nickname">The nickname of the user.</param>
        /// <param name="message">The message being sent by the user.</param>
        public void SendBroadCastMessage(string nickname,string message)
        {
            Clients.All.broadCastMessage(nickname, message);
        }

    }
}