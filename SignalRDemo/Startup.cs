using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(SignalRDemo.Startup))]
namespace SignalRDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SignalRDemo.Hubs.BallHub.Initialize();
            app.MapSignalR();
        }
    }
}
