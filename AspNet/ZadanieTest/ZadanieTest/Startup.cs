using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZadanieTest.Startup))]
namespace ZadanieTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
