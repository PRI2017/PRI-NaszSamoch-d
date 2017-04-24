using PRI_NaszSamochod.MobileAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRI_NaszSamochod
{
    public class LoginController : ApiController
    {
        public LoginController()
        {
        }

        private readonly IKeysHolder _keysHolder;
        public LoginController(IKeysHolder keysHolder)
        {
            _keysHolder = keysHolder;
        }

        // GET api/<controller>
        public string Get()
        {
            return _keysHolder.SerializePublicKey();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}