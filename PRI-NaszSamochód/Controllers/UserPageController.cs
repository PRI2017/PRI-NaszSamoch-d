using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PRI_NaszSamochód.Models;

namespace PRI_NaszSamochód.Controllers
{
    [Authorize]
    public class UserPageController : Controller
    {
        // GET: UserPage
        public ActionResult Index()
        {
            return RedirectToAction("UserPageHeader");
        }

        public ActionResult UserPageHeader(string userId)
        {
            if (userId != null)
            {
                ProfileViewModel model =
                    new ProfileViewModel(ApplicationDbContext.Create().Users.Single(u => u.Id == userId));
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
            
          }
        [AllowAnonymous]
        public ActionResult UserPageContent()
        {
            var curUserId = User.Identity.GetUserId();
            return View(new PostViewModelList(ApplicationDbContext.Create().Posts
                .Where(p => p.Creator.Id == curUserId )
                .Take(15).ToList()));
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

       

        [HttpPost]
        public void AddPost(PostModel post)
        {
            
        }
    }
}