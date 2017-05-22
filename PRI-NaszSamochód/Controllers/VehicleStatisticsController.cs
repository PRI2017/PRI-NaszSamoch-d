using Newtonsoft.Json;
using PRI_NaszSamochód.Models;
using PRI_NaszSamochód.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

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

        public ActionResult GetVehiclesStatistics()
        {
            //return RedirectToAction("VehicleStatisticsHeader");
            return View();
        }

        public ActionResult VehicleStatisticsHeader(int? vId, int? sId)
        {
            if (vId == null || sId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleStatisticsModel model = _context.Vehicles.Find(vId).
                Statistics.
                Find(x => x.Key == sId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult VehicleStatisticsContent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Key, KilometersDriven, FuelUsed, MaxVelocity, RecordTime")]VehicleStatisticsModel model, int vId)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Find(vId).Statistics.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_context.Vehicles.Find(vId).Statistics);
        }

        public ActionResult FuelChart(int? vId)
        {
            List<DataPoint> chartPoints = new List<DataPoint>();

            foreach(var item in _context.Vehicles.Find(vId).Statistics)
            {
                chartPoints.Add(new DataPoint(item.RecordTime, item.FuelUsed));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(chartPoints);
            return View();
        }

        public ActionResult KilometersDrivenChart(int? vId)
        {
            List<DataPoint> chartPoints = new List<DataPoint>();

            foreach (var item in _context.Vehicles.Find(vId).Statistics)
            {
                chartPoints.Add(new DataPoint(item.RecordTime, item.KilometersDriven));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(chartPoints);
            return View();
        }

        public ActionResult MaxVelocityChart(int? vId)
        {
            List<DataPoint> chartPoints = new List<DataPoint>();
            try
            {
                foreach (var item in _context.Vehicles.Find(vId).Statistics)
                {
                    chartPoints.Add(new DataPoint(item.RecordTime, item.MaxVelocity));
                }
            }
            catch (Exception) { }
            ViewBag.DataPoints = JsonConvert.SerializeObject(chartPoints);
            return View();
        }
    }
}