using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GivingBack2.Startup))]
namespace GivingBack2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
