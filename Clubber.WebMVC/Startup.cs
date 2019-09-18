using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Clubber.WebMVC.Startup))]
namespace Clubber.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
