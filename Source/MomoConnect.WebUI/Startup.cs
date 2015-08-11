using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MomoConnect.WebUI.Startup))]
namespace MomoConnect.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
