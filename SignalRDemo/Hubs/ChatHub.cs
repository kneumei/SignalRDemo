using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRDemo.Hubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> _users = new Dictionary<string, string>();

        public override Task OnConnected()
        {
            _users[Context.ConnectionId] = String.Empty;
            Clients.Others.userJoined();
            return base.OnConnected();
        }

        public void Send(string name, string message)
        {
            _users[Context.ConnectionId] = name;
            Clients.All.broadcastMessage(name, message);
        }

        public override Task OnDisconnected()
        {
            Clients.Others.userLeft(_users[Context.ConnectionId]);
            _users.Remove(Context.ConnectionId);
            return base.OnDisconnected();
        }
    }

}