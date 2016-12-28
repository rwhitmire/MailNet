using Microsoft.AspNet.SignalR;

namespace MailNet.Web
{
    public class MailHub : Hub
    {
        public void ReceiveMessage(string message)
        {
            Clients.All.receiveMessage(message);
        }
    }
}
