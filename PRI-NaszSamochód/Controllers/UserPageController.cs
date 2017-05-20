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
        [AllowAnonymous]
        public ActionResult UserPageContent()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult UserInfo()
        {
            String id = User.Identity.GetUserId();
            ProfileViewModel model = new ProfileViewModel(ApplicationDbContext.Create().Users.Single(u => u.Id == id));
            return View(model);
        }
        public ActionResult UserStatistics()
        {
            String id = User.Identity.GetUserId();
            ProfileViewModel model = new ProfileViewModel(ApplicationDbContext.Create().Users.Single(u => u.Id == id));
            return View();
        }
        public ActionResult UserFriends()
        {
            String id = User.Identity.GetUserId();
            ProfileViewModel model = new ProfileViewModel(ApplicationDbContext.Create().Users.Single(u => u.Id == id));
            return View(model);
        }
        public ActionResult UserGallery()
        {
            String id = User.Identity.GetUserId();
            ProfileViewModel model = new ProfileViewModel(ApplicationDbContext.Create().Users.Single(u => u.Id == id));
            return View(model);
        }

        public ActionResult UserPosts()
        {
            return View(new PostViewModelList(ApplicationDbContext.Create().Posts
                .Where(p => p.Creator.Id == User.Identity.GetUserId())
                .Take(15).ToList()));

        }
    }
}