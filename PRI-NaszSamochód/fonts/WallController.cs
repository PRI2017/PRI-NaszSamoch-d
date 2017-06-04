using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PRI_NaszSamochód.Models;

namespace PRI_NaszSamochód.Controllers
{   [Authorize]
    public class WallController : Controller
    {
       
        public ActionResult WallContent()
        {
            var db = ApplicationDbContext.Create();
            var currentUserId = User.Identity.GetUserId();
            var posts = (from p in db.Posts
                join friend in db.Friends on
                p.Creator equals friend.User2
                where friend.User1.Id == currentUserId
                orderby p.Id descending 
                select p
                
                ).ToList();

            
            return View(new PostViewModelList(posts));
        }


        public ActionResult AddPostView()
        {
            return View();
        }
        [HttpPost]
        public void AddPost(PostModel post)
        {
            
           var db =  ApplicationDbContext.Create();
            post.Added = DateTime.Now;
            post.Creator = db.Users.Find(User.Identity.GetUserId());
            db.Posts.Add(post);
            db.SaveChanges();
        }


    }
}