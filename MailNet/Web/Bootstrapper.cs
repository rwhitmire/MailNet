using Nancy;

namespace MailNet.Web
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider => new RootPathProvider();
    }

    public class RootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return "Web";
        }
    }
}
