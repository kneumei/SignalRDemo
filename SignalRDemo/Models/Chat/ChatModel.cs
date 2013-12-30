using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRDemo.Models.Chat
{
    public class ChatModel
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public ChatModel()
        {
        }

        public ChatModel(string name, string message)
        {
            Name = name;
            Message = message;
        }
    }
}