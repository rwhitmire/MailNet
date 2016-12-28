using Nancy;

namespace MailNet.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["index"];
        }
    }
}
