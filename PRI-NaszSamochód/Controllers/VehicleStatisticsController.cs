using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRI_NaszSamochód.Models;
using System.Web.Mvc;
using System.Net;

namespace PRI_NaszSamochód.Controllers
{
    [Authorize]
    public class VehicleStatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleStatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return RedirectToAction("VehicleStatisticsHeader");
        }

        [HttpGet]
        public ActionResult VehicleStatisticsHeader(int? vehicleId)
        {
            if(vehicleId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleStatisticsModel model = _context.Cars.Find(vehicleId).Statistics;
            if (model == null)
            {
                model = _context.Motorcycles.Find(vehicleId).Statistics;
            }
            return View(model);
        }
    }
}