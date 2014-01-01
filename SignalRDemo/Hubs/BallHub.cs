using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRDemo.Models.Ball;

namespace SignalRDemo.Hubs
{
    public class BallHub : Hub
    {
        private static List<BallModel> _ballModels = new List<BallModel>();

        public void SendMove(int index, int x, int y)
        {
            var shapeConfig = _ballModels[index];
            shapeConfig.X = x;
            shapeConfig.Y = y;
            Clients.Others.moveIt(index, x, y);
        }

        public void GetShapes()
        {
            Clients.Caller.setShapes(_ballModels);
        }

        public static void Initialize()
        {
            var colors = new List<string>() { "red", "green", "yellow", "blue", "purple", "orange" };

            int radius = 30;
            int y = radius * 2;
            foreach (var color in colors)
            {
                _ballModels.Add(new BallModel { X = radius * 2, Y = y, Fill = color, Radius = radius });
                y = y + (radius * 2);
            }
        }
    }

}