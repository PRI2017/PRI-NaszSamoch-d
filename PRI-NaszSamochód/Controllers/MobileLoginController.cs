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
            return View();
        }

        // POST: MobileLogin/Login
        [HttpPost]
        public ActionResult Login(MobileLoginModel model)
        {
            Debug.WriteLine(model.Password + model.Email);
            using (Context context = new Context())
            {
                try
                {
                    string decryptedPassword = CryptoRSA.Decrypt(KeysHolder.PrivateKey, Encoding.Unicode.GetBytes(model.Password), false);
                    var usr = context.mobileLoginModel.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    if (usr != null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.OK);
                    }
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return new HttpStatusCodeResult(HttpStatusCode.NoContent);
                }
            }
        }
    }
}