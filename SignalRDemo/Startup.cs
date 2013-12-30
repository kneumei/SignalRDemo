using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using SignalRDemo.Hubs;
using System.Collections.Generic;
using Microsoft.Owin.Cors;
using SignalRDemo.Connections;

[assembly: OwinStartup(typeof(SignalRDemo.Startup))]

namespace SignalRDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var shapeConfigService = new ShapeConfigService();
            var colors = new List<string>() { "red", "green", "yellow", "blue", "purple", "orange" };

            int radius = 30;
            int y = radius * 2;
            foreach (var color in colors)
            {
                shapeConfigService.AddShapeConfig(new ShapeConfig { X = radius * 2, Y = y, Fill = color, Radius = radius });
                y = y + (radius * 2);
            }

            GlobalHost.DependencyResolver.Register(
                typeof(DemoHub),
                () => new DemoHub(shapeConfigService));

            app.Map("/signalr", map =>
            {
              
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                     EnableJSONP = true
                };
                map.RunSignalR(hubConfiguration);
            });

            app.MapSignalR<ChatConnection>("/signalrchat");
        }
    }
}
