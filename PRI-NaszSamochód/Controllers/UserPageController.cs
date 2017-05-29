using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PRI_NaszSamochod;
using PRI_NaszSamochód.Models;
using PRI_NaszSamochód.Utilities;
using Newtonsoft.Json;

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
            //String id = User.Identity.GetUserId();
            //ProfileViewModel model = new ProfileViewModel(ApplicationDbContext.Create().Users.Single(u => u.Id == id));
            //return View();
            List<DataPoint> chartPoints = new List<DataPoint>();
            try
            {
                //foreach (var item in _context.Vehicles.Find(vId).Statistics)
                //{
                //    chartPoints.Add(new DataPoint(item.RecordTime, item.MaxVelocity));
                //}
                for (var i = 0; i < 10; i++)
                {
                    chartPoints.Add(new DataPoint(i, i-1));
                }
            }
            catch (Exception) { }
            ViewBag.DataPoints = JsonConvert.SerializeObject(chartPoints);
            return View(chartPoints);
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