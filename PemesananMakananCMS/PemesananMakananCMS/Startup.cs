using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PemesananMakananCMS.Startup))]
namespace PemesananMakananCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
