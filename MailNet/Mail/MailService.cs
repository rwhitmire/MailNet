using System;
using System.Threading;
using System.Threading.Tasks;
using SmtpServer;

namespace MailNet.Mail
{
    public class MailService
    {
        public void Start()
        {
            Console.WriteLine("mail service started.");
            Task.Run(async () => await StartAsync());
        }

        public void Stop()
        {
            Console.WriteLine("mail service stopped.");
        }

        private static async Task StartAsync()
        {
            var smtpOptions = new OptionsBuilder()
                .ServerName("localhost")
                .Port(4001)
                .MessageStore(new MessageStoreFactory())
                .MailboxFilter(new MailboxFilterFactory())
                .UserAuthenticator(new UserAuthenticator())
                .Build();

            var smtpServer = new SmtpServer.SmtpServer(smtpOptions);
            await smtpServer.StartAsync(CancellationToken.None);
        }

        public void OnReceiveMail(Action action)
        {
            action();
        }
    }
}
