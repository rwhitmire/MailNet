using System;
using System.Threading.Tasks;
using SmtpServer;
using SmtpServer.Mail;
using SmtpServer.Storage;

namespace MailNet.Mail
{
    internal class MailboxFilter : IMailboxFilter
    {
        private ISessionContext _context;

        public MailboxFilter(ISessionContext context)
        {
            _context = context;
        }

        public Task<MailboxFilterResult> CanAcceptFromAsync(ISessionContext context, IMailbox from, int size = 0)
        {
            Console.WriteLine("MyMailboxFilter.CanAcceptFromAsync");
            return Task.FromResult(MailboxFilterResult.Yes);
        }

        public Task<MailboxFilterResult> CanDeliverToAsync(ISessionContext context, IMailbox to, IMailbox @from)
        {
            Console.WriteLine("MyMailboxFilter.CanDeliverToAsync");
            return Task.FromResult(MailboxFilterResult.Yes);
        }
    }
}