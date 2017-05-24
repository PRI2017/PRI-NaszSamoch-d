<<<<<<< HEAD
﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using PRI_NaszSamochód.Models;
//using System.Web.Mvc;
//using System.Net;

//namespace PRI_NaszSamochód.Controllers
//{
//    [Authorize]
//    public class VehicleStatisticsController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public VehicleStatisticsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public ActionResult Index()
//        {
//            return RedirectToAction("VehicleStatisticsHeader");
//        }

//        public ActionResult VehicleStatisticsHeader(int? Id)
//        {
//            if (Id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            VehicleStatisticsModel model = _context.Vehicles.Find(Id).Statistics;
//            if (model == null)
//            {
//                return HttpNotFound();
//            }
//            return View(model);
//        }

//        public ActionResult VehicleStatisticsContent()
//        {
//            return View();
//        }

//        // POST: Groups/Create
//        [HttpPost]
//        public ActionResult Create([Bind(Include = "Key, KilometersDriven, FuelUsed, MaxVelocity, RecordStartTime, RecordEndTime")]VehicleStatisticsModel model, int vehicleId)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Vehicles.Find(vehicleId).Statistics = model;
//                _context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(_context.Vehicles.Find(vehicleId).Statistics);
//        }

//        // GET: Groups/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            GroupModel group = _context.Groups.Find(id);
//            if (group == null)
//            {
//                return HttpNotFound();
//            }
//            return View(group);
//        }

//        // POST: Groups/Edit/5
//        [System.Web.Mvc.HttpPut]
//        public ActionResult Edit([Bind(Include = "Key, KilometersDriven, FuelUsed, MaxVelocity, RecordStartTime, RecordEndTime")]VehicleStatisticsModel model, int vehicleId)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Vehicles.Find(vehicleId).Statistics = model;
//                _context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(model);
//        }

//        // GET: Groups/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            GroupModel group = _context.Groups.Find(id);
//            if (group == null)
//            {
//                return HttpNotFound();
//            }
//            return View(group);
//        }

//        // POST: Groups/Delete/5
//        [System.Web.Mvc.HttpDelete, System.Web.Mvc.ActionName("Delete")]
//        public ActionResult DeleteConfirmed(int vehicleId)
//        {
//            VehicleModel model = _context.Vehicles.Find(vehicleId);
//            if (model == null)
//            {
//                return HttpNotFound();
//            }
//            if (!(model.Statistics == null))
//            {
//                _context.Vehicles.Find(vehicleId).Statistics = null;
//                _context.SaveChanges();
//            }
//            return RedirectToAction("Index");
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
=======
﻿using Newtonsoft.Json;
>>>>>>> origin/Groups
using PRI_NaszSamochód.Models;
using PRI_NaszSamochód.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
<<<<<<< HEAD
using Newtonsoft.Json;
=======
using System.Web.Mvc;
>>>>>>> origin/Groups

namespace PRI_NaszSamochód.Controllers
{
    [Authorize]
    public class VehicleStatisticsController : Controller
    {
        public ActionResult UserStatistics()
        {
            List<DataPoint> dataPoints = new List<DataPoint>{
                new DataPoint(10, 22),
                new DataPoint(20, 36),
                new DataPoint(30, 42),
                new DataPoint(40, 51),
                new DataPoint(50, 46),
            };

<<<<<<< HEAD
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View(dataPoints);
        }

=======
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
>>>>>>> origin/Groups
    }
}
