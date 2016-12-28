using SmtpServer;
using SmtpServer.Storage;

namespace MailNet.Mail
{
    internal class MessageStoreFactory : IMessageStoreFactory
    {
        public IMessageStore CreateInstance(ISessionContext context)
        {
            return new MessageStore(context);
        }
    }
}