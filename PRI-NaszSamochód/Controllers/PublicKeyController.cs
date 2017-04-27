using PRI_NaszSamochód.MobileAuthentication;
using System.Web.Http;

namespace PRI_NaszSamochod
{
    public class PublicKeyController : ApiController
    {

        private readonly IKeysHolder _keysHolder;

        public PublicKeyController()
        {
        }
        
        public PublicKeyController(IKeysHolder keysHolder)
        {
            _keysHolder = keysHolder;
        }

        // GET api/<controller>
        public string Get()
        {
            return _keysHolder.SerializePublicKey();
        }
    }
}