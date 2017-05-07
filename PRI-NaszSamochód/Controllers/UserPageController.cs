using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PRI_NaszSamochod;
using PRI_NaszSamochód.Models;

namespace PRI_NaszSamochód.Controllers
{   [Authorize]
    public class UserPageController : Controller
    {
        // GET: UserPage
        public ActionResult Index()
        {
            return RedirectToAction("UserPageHeader");
        }

        public ActionResult UserPageHeader()
        {
            String id = User.Identity.GetUserId();
            ProfileViewModel model = new ProfileViewModel(ApplicationDbContext.Create().Users.Single(u => u.Id == id ));
            return View(model);
        }
    }
}