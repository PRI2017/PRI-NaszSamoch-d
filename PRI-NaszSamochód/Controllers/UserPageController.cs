using System;
using System.Data.Entity;
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
        public ActionResult UserPageContent(string userId)
        {
            if (userId != null)
            {
                return View(new PostViewModelList(ApplicationDbContext.Create().Posts
                    .Where(p => p.Creator.Id == userId)
                    .Take(15).OrderByDescending(p => p.Id).ToList()));
            }
            else
            {
                return HttpNotFound();
            }

        }
        [AllowAnonymous]
        public ActionResult UserInfo(string userId)
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
        public ActionResult UserStatistics(string userId)
        {
            ProfileViewModel model = new ProfileViewModel(ApplicationDbContext.Create().Users.Single(u => u.Id == userId));
            return View(model);
        }
        public ActionResult UserFriends(string userId)
        {
            var model = new FriendsView(ApplicationDbContext.Create().Friends.Where(f => f.User1.Id == userId &&  (f.Status == FriendStatus.Friends)).Include(f => f.User2).ToList());
            
            return View(model);
        }
        public ActionResult UserGallery(string userId)
        {
            //String id = User.Identity.GetUserId();
            ProfileViewModel model = new ProfileViewModel(ApplicationDbContext.Create().Users.Single(u => u.Id == userId));
            return View(model);
        }

       

        [HttpPost]
        public void AddPost(PostModel post)
        {
            
        }
    }
}