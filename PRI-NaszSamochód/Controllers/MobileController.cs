using Microsoft.AspNet.Identity.Owin;
using PRI_NaszSamochod;
using PRI_NaszSamochod.MobileAuthentication;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;
using PRI_NaszSamochod.Models;

namespace PRI_NaszSamochód.Controllers
{
    public class MobileController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly KeysHolder _keysHolder;

        public MobileController()
        {

        }

        public MobileController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, KeysHolder keysHolder)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _keysHolder = keysHolder;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // POST: Mobile/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SignInStatus x = await SignInManager.PasswordSignInAsync(
                model.Email,
                CryptoRSA.Decrypt(
                    Convert.FromBase64String(model.Password),
                    _keysHolder.PrivateKey),
                model.RememberMe,
                shouldLockout: false);

            switch (x)
            {
                case SignInStatus.Success:
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                case SignInStatus.Failure:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}