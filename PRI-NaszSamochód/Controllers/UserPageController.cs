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
using System.Collections;
using System.Web.Helpers;

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
            var _context = new ApplicationDbContext();
            ArrayList xValues = new ArrayList();
            ArrayList yValues = new ArrayList();

            var results = (from c in _context.UserStatistics select c);

            results.ToList().ForEach(x => xValues.Add(x.RecordTime));
            results.ToList().ForEach(y => xValues.Add(y.MaxVelocity));

            new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla3D)
                .AddTitle("MAX VELOCITY")
                .AddSeries("Default", chartType: "Column", xValue: xValues, yValues: yValues)
                .Write("bmp");

            return null;
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