using SmtpServer;
using SmtpServer.Storage;

namespace MailNet.Mail
{
    internal class MailboxFilterFactory : IMailboxFilterFactory
    {
        public IMailboxFilter CreateInstance(ISessionContext context)
        {
            return new MailboxFilter(context);
        }
    }
}