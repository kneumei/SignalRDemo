using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRDemo.Hubs
{
    public class DemoHub : Hub
    {
        public DemoHub(ShapeConfigService shapeConfigService)
        {
            _shapeConfigService = shapeConfigService;
        }

        public void SendMove(int index, int x, int y)
        {
            var shapeConfig = _shapeConfigService.GetShapeConfig(index);
            shapeConfig.X = x;
            shapeConfig.Y = y;
            Clients.Others.moveIt(index, x, y);
        }

        public void GetShapes()
        {
            Clients.Caller.setShapes(_shapeConfigService.ShapeConfigs);
        }

        private readonly ShapeConfigService _shapeConfigService;
    }

    public class ShapeConfigService
    {
        public ShapeConfigService()
        {
             _shapeConfig = new List<ShapeConfig>();
        }

        public List<ShapeConfig> ShapeConfigs { get { return _shapeConfig; } }
        public void AddShapeConfig(ShapeConfig shapeConfig)
        {
            _shapeConfig.Add(shapeConfig);
        }

        public ShapeConfig GetShapeConfig(int i)
        {
            return _shapeConfig[i];
        }

        private readonly List<ShapeConfig> _shapeConfig;
    }

    public class ShapeConfig
    {
        public ShapeConfig()
        {
            X = 20;
            Y = 20;
            Radius = 40;
            Fill = "red";
            Stroke = "black";
            StrokeWidth = 4;
            Draggable = true;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public string Fill { get; set; }
        public string Stroke { get; set; }
        public int StrokeWidth { get; set; }
        public Boolean Draggable { get; set; }
    }
}