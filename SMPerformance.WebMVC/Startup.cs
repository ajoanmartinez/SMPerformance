using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMPerformance.WebMVC.Startup))]
namespace SMPerformance.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
