using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRDemo.Models.Ball
{
    public class BallModel
    {
        public BallModel()
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