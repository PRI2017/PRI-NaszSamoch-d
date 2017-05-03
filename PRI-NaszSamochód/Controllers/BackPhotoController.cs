using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PRI_NaszSamochód.Controllers
{
    public class BackPhotoController : Controller
    {
        [System.Web.Mvc.Route("BackPhoto/{userId}")]
        [System.Web.Mvc.HttpGet]
        public ActionResult Index(String userId)
        {
            Debug.WriteLine(User.Identity.GetUserId());
            var dir = Server.MapPath("/ProfilePhoto");
            var path = Path.Combine(dir, userId + ".jpg");
            Debug.WriteLine(userId);
            return base.File(path, "image/jpeg");
        }
    }
}