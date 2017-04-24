using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRI_NaszSamochód.Startup))]
namespace PRI_NaszSamochód
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
