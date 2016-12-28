using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MimeKit;
using SmtpServer;
using SmtpServer.Mail;
using SmtpServer.Protocol;
using SmtpServer.Storage;

namespace MailNet.Mail
{
    internal class MessageStore : IMessageStore
    {
        private ISessionContext _context;

        public MessageStore(ISessionContext context)
        {
            _context = context;
        }

        public Task<SmtpResponse> SaveAsync(ISessionContext context, IMimeMessage message, CancellationToken cancellationToken)
        {
            Console.WriteLine("MyMessageStore.SaveAsync");
            Console.WriteLine(message.Mime);

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(message.Mime.ToString()));
            var parser = new MimeParser(stream);
            var parsedMessage = parser.ParseMessage();

            Store.AddMessage(parsedMessage);

            return Task.FromResult(new SmtpResponse(SmtpReplyCode.Ok));
        }
    }
}
