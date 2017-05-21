using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRI_NaszSamochód.Models;

namespace PRI_NaszSamochód.Controllers
{
    [Authorize]
    public class RouteStatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RouteStatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: RouteStatistics
        [ActionName("GetRouteStatsHeader")]
        public ActionResult GetRouteStatsHeader()
        {
            //return RedirectToAction("RouteStatisticsHeader");
            return View();
        }

        public ActionResult RouteStatisticsHeader(int? routeId)
        {
            if(routeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteStatisticsModel model = _context.Routes.Find(routeId).Statistics;
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        
        public ActionResult RouteStatisticsContent()
        {
            return View();
        }
    }
}
