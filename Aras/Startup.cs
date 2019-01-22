using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aras.Startup))]
namespace Aras
{
    // new comment by Milad
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
