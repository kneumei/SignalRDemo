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
        public override Task OnConnected()
        {
            ChatHubUsers.users[Context.ConnectionId] = String.Empty;
            Clients.All.userJoined();
            return base.OnConnected();
        }

        public void Send(string name, string message)
        {
            ChatHubUsers.users[Context.ConnectionId] = name;
            Clients.All.broadcastMessage(name, message);
        }

        public override Task OnDisconnected()
        {
            Clients.All.userLeft(ChatHubUsers.users[Context.ConnectionId]);
            ChatHubUsers.users.Remove(Context.ConnectionId);
            return base.OnDisconnected();
        }
    }

    public class ChatHubUsers
    {
        public static Dictionary<string, string> users = new Dictionary<string, string>();
    }
}