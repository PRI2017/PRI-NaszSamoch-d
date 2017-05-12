using Microsoft.Owin;
using Owin;
using PRI_NaszSamochód.MobileAuthentication;

[assembly: OwinStartupAttribute(typeof(PRI_NaszSamochód.Startup))]
namespace PRI_NaszSamochód
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //TODO: Delete this two lines when the mobile login works !!!
            CryptoRSA.TestEncDec("Testowe1234$");
        }
    }
}
