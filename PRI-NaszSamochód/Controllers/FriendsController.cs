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
    }
}