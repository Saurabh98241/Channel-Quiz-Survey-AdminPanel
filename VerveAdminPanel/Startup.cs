using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VerveAdminPanel.Startup))]
namespace VerveAdminPanel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
