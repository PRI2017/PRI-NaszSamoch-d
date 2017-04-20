using PRI_NaszSamochód.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRI_NaszSamochod.MobileAuthentication;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Web.Http;

namespace PRI_NaszSamochód.Controllers
{
    public class MobileLoginController : ApiController
    {
        // GET: MobileLogin
        //public ActionResult Index()
        //{

        //}

        // GET: MobileLogin/Login
        public string PublicKey()
        {
            return new KeysHolder().SerializeKey();
        }

        // POST: MobileLogin/Login
       //[HttpPost]
       // public ActionResult Login(MobileLoginModel model)
       // {
       //     return View();
       // }
    }
}