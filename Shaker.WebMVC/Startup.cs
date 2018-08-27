using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shaker.WebMVC.Startup))]
namespace Shaker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
