using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

namespace MailNet.Web
{
    public class WebService
    {
        private IDisposable _host;

        public void Start()
        {
            _host = WebApp.Start<Startup>("http://+:5000");

            Console.WriteLine("Running on http://localhost:5000");

            Store.OnMessageReceived(() =>
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<MailHub>();
                context.Clients.All.receiveMessage("foobar!");
            });
        }

        public void Stop()
        {
            Console.WriteLine("stopped.");
            _host.Dispose();
        }
    }
}
