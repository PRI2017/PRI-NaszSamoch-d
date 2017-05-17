using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRI_NaszSamochód.Models;

namespace PRI_NaszSamochód.Controllers
{
    public class RouteStatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RouteStatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: RouteStatistics
        public ActionResult Index()
        {
            return RedirectToAction("RouteStatisticsHeader");
        }

        public ActionResult RouteStatisticsHeader(int? routeId)
        {
            if(routeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteStatisticsModel model = _context.RoutesStatistics.Find(routeId);
            return View(model);
        }
    }
}