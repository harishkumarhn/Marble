using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Marbale.ManagementStudio.Startup))]
namespace Marbale.ManagementStudio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
