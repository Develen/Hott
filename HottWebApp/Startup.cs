using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HottWebApp.Startup))]
namespace HottWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
