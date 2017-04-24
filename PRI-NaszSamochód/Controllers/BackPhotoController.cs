using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRI_NaszSamochód.Controllers
{
    public class BackPhotoController : Controller
    {
        // GET: BackPhoto
        public ActionResult Index()
        {
            Console.WriteLine(User.Identity.Name);
            var dir = Server.MapPath("/BackGroundPhoto");
            var path = Path.Combine(dir, User.Identity.Name + ".jpg");
            return base.File(path, "image/jpeg");
        }
    }
}