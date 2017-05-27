using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRI_NaszSamochód.Controllers
{
    public class WallController : Controller
    {
        // GET: Wall
        public ActionResult WallContent()
        {
            return View("WallContent");
        }
    }
}