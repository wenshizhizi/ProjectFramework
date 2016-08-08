using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Framework.web.Startup))]
namespace Framework.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
