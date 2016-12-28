using System.Threading.Tasks;
using SmtpServer.Authentication;

namespace MailNet.Mail
{
    internal class UserAuthenticator : IUserAuthenticator
    {
        public Task<bool> AuthenticateAsync(string user, string password)
        {
            return Task.FromResult(true);
        }
    }
}