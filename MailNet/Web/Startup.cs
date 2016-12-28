using Microsoft.AspNet.SignalR;
using Owin;

namespace MailNet.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HubConfiguration {EnableDetailedErrors = true};
            app.MapSignalR(configuration);
            app.UseNancy();
        }
    }
}
