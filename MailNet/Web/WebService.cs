using System;
using System.Linq;
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

            Store.OnMessageReceived(message =>
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<MailHub>();

                context.Clients.All.receiveMessage(new
                {
                    from = message.From.Mailboxes.Select(x => new {x.Name, x.Address}),
                    to = message.To.Mailboxes.Select(x => new {x.Name, x.Address}),
                    date = message.Date,
                    htmlBody = message.HtmlBody,
                    textBody = message.TextBody,
                    subject = message.Subject
                });
            });
        }

        public void Stop()
        {
            Console.WriteLine("stopped.");
            _host.Dispose();
        }
    }
}
