using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XANDER.Startup))]
namespace XANDER
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
