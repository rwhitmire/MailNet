using System;
using System.Threading;
using System.Threading.Tasks;
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
            Store.AddMessage();
            return Task.FromResult(new SmtpResponse(SmtpReplyCode.Ok));
        }
    }
}
