using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parakeet.Web.Startup))]
namespace Parakeet.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
