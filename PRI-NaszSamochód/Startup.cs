using Microsoft.Owin;
using Owin;
using PRI_NaszSamochod.MobileAuthentication;
using System.Diagnostics;

[assembly: OwinStartupAttribute(typeof(PRI_NaszSamochod.Startup))]
namespace PRI_NaszSamochod
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            KeysHolder kh = new KeysHolder();
            kh.GenerateKeys(4096);
        }
    }
}
