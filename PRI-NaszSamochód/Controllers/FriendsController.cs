using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PRI_NaszSamochód.Models;

namespace PRI_NaszSamochód.Controllers
{
    public class FriendsController : Controller
    {
        // GET: Friends
        public ActionResult Requests()
        {
            var db = ApplicationDbContext.Create();
            var curUserId = User.Identity.GetUserId();
            var requestedFriends = db.Friends.Where(f => f.User2.Id == curUserId && f.Status == FriendStatus.Requested).Include(P => P.User1);
            return View();
        }
        [HttpPost]
        public void DeleteFriend(string userId)
        {
            if (userId != null)
            {
                var db = ApplicationDbContext.Create();
                db.Friends.Remove(db.Friends.Single(f => f.User2.Id == userId));
                db.Friends.Remove(db.Friends.Single(f => f.User1.Id == userId));
                db.SaveChanges();
            }
           
        }
        [HttpGet]
        public ActionResult SearchFriend(string term)
        {
           if (term != null)
            {
                var db = ApplicationDbContext.Create();
                List<SearchFriendModel> models = (from u in db.Users
                    where u.UserName.Contains(term)
                    select new SearchFriendModel(){Id = u.Id,UserName = u.UserName}).ToList();
                
                return Json(models,JsonRequestBehavior.AllowGet);
            }
            return HttpNotFound();


        }

        public void AddFriend(string userId)
        {  
            var db = ApplicationDbContext.Create();
            var userExternal = db.Users.Single(u => u.Id == userId);
            var curUserId = User.Identity.GetUserId();
            var curUser = db.Users.Single(u => u.Id == curUserId);
            if (userExternal != null)
            { 
              var requestFriend = new FriendModel(){User1 = curUser, User2 = userExternal,Status = FriendStatus.Requested};
              var respondFriend = new FriendModel(){User1 = userExternal,User2 = curUser, Status = FriendStatus.Pending};
                db.Friends.Add(respondFriend);
                db.Friends.Add(requestFriend);
                db.SaveChanges();
            }

        }

        public ActionResult FriendRequests()
        {
            var db = ApplicationDbContext.Create();
            var curUserId = User.Identity.GetUserId();
            FriendRequestsModel model = new FriendRequestsModel(){Requests = db.Friends.Where(f => f.User2.Id == curUserId 
            && f.Status == FriendStatus.Requested)
           .Include(f=> f.User1).Include(f => f.User2).ToList()};
            return PartialView(model);
        }
        [HttpPost]
        public void AcceptRequest(string userId)
        {
            
        }
    }
}