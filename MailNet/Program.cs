using System;
using MailNet.Mail;
using MailNet.Web;
using Topshelf;

namespace MailNet
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(configurator =>
            {
                configurator.Service<RootService>(x =>
                {
                    x.ConstructUsing(name => new RootService());
                    x.WhenStarted(rs => rs.Start());
                    x.WhenStopped(rs => rs.Stop());
                });

                configurator.RunAsLocalSystem();

                configurator.SetDescription("MailNet Description");
                configurator.SetDisplayName("MailNet");
                configurator.SetServiceName("MailNet");
            });
        }
    }

    public class RootService
    {
        private readonly MailService _mailService;
        private readonly WebService _webService;

        public RootService()
        {
            _mailService = new MailService();
            _webService = new WebService();
        }

        public void Start()
        {
            _mailService.Start();
            _webService.Start();
        }

        public void Stop()
        {
            _mailService.Stop();
            _webService.Stop();
        }
    }
}
