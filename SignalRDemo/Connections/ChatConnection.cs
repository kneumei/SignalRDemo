using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRDemo.Models.Chat;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SignalRDemo.Connections
{
    public class ChatConnection : PersistentConnection 
    {
        private readonly Dictionary<string, string> _clients = new Dictionary<string, string>();

        protected override Task OnConnected(IRequest request, string connectionId)
        {
            _clients.Add(connectionId, string.Empty);
            ChatModel chatData = new ChatModel("Server", "A new user has joined the room.");
            return Connection.Broadcast(chatData);
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            ChatModel chatData = JsonConvert.DeserializeObject<ChatModel>(data);
            _clients[connectionId] = chatData.Name;
            return Connection.Broadcast(chatData);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId)
        {
            string name = _clients[connectionId];
            ChatModel chatData = new ChatModel("Server", string.Format("{0} has left the room.", name));
            _clients.Remove(connectionId);
            return Connection.Broadcast(chatData);
        }
    }
}