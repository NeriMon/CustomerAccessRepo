using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pointwest.CustomerAccess.Web.Startup))]
namespace Pointwest.CustomerAccess.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
