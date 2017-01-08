using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(website_negaheno.Startup))]
namespace website_negaheno
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
