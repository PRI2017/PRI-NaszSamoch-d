using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRI_NaszSamochod.Startup))]
namespace PRI_NaszSamochod
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
