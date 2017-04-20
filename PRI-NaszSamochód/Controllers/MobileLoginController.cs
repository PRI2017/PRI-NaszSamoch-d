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

namespace PRI_NaszSamochód.Controllers
{
    public class MobileLoginController : Controller
    {
        // GET: MobileLogin
        public ActionResult Index()
        {
            return View();
        }

        // GET: MobileLogin/Login
        public ActionResult Login()
        {
            CryptoRSA.TestEncDec();
            return View();
        }

        // POST: MobileLogin/Login
       //[HttpPost]
       // public ActionResult Login(MobileLoginModel model)
       // {
       //     return View();
       // }
    }
}