using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PRI_NaszSamochód.Models;

namespace PRI_NaszSamochód.Controllers
{
    [Authorize]





    public class HomeController : Controller
    {
        //private ApplicationUserManager _userManager;

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        //public HomeController( ApplicationUserManager userManager)
        //{
        //    UserManager = userManager;
        //}

        public ActionResult Index()
        {
            return RedirectToAction("Index", "UserPage");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserPage()
        {


            return RedirectToAction("Index","UserPage");
        }
    }
}