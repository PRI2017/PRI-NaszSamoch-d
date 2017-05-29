//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Newtonsoft.Json;
//using PRI_NaszSamochód.Models;
//using PRI_NaszSamochód.Utilities;
//using System.Net;
//using System.Web.Mvc;
//using System.Web.Http;

//namespace PRI_NaszSamochód.Controllers
//{
//    [System.Web.Mvc.Authorize]
//    public class VehicleStatisticsController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public VehicleStatisticsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public ActionResult UserStatistics(/* int? vId */)
//        {
//            List<DataPoint> chartPoints = new List<DataPoint>();
//            try
//            {
//                //foreach (var item in _context.Vehicles.Find(vId).Statistics)
//                //{
//                //    chartPoints.Add(new DataPoint(item.RecordTime, item.MaxVelocity));
//                //}
//                for (var i = 0; i < 10; i++)
//                {
//                    chartPoints.Add(new DataPoint(DateTime.Now, i));
//                }
//            }
//            catch (Exception) { }
//            ViewBag.DataPoints = JsonConvert.SerializeObject(chartPoints);
//            return View(chartPoints);
//        }

//        //public ActionResult VehicleStatisticsHeader(int? Id)
//        //{
//        //    if (Id == null)
//        //    {
//        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//        //    }
//        //    VehicleStatisticsModel model = _context.Vehicles.Find(Id).Statistics;
//        //    if (model == null)
//        //    {
//        //        return HttpNotFound();
//        //    }
//        //    return View(model);
//        //}

//        //public ActionResult VehicleStatisticsContent()
//        //{
//        //    return View();
//        //}

//        //POST: Groups/Create
//       [System.Web.Mvc.HttpPost]
//        public ActionResult Create([FromBody]VehicleStatisticsModel model, int vehicleId)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Vehicles.Find(vehicleId).Statistics.Add(model);
//                _context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(_context.Vehicles.Find(vehicleId).Statistics);
//        }

//        //GET: Groups/Edit/5
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

//        //POST: Groups/Edit/5
//        [System.Web.Mvc.HttpPut]
//        public ActionResult Edit([FromBody]VehicleStatisticsModel model, int vehicleId)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Vehicles.Find(vehicleId).Statistics.Add(model);
//                _context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(model);
//        }

//        //GET: Groups/Delete/5
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

//        //POST: Groups/Delete/5
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
//        public ActionResult FuelChart(int? vId)
//        {
//            List<DataPoint> chartPoints = new List<DataPoint>();

//            foreach (var item in _context.Vehicles.Find(vId).Statistics)
//            {
//                chartPoints.Add(new DataPoint(item.RecordTime, item.FuelUsed));
//            }

//            ViewBag.DataPoints = JsonConvert.SerializeObject(chartPoints);
//            return View();
//        }

//        public ActionResult KilometersDrivenChart(int? vId)
//        {
//            List<DataPoint> chartPoints = new List<DataPoint>();

//            foreach (var item in _context.Vehicles.Find(vId).Statistics)
//            {
//                chartPoints.Add(new DataPoint(item.RecordTime, item.KilometersDriven));
//            }

//            ViewBag.DataPoints = JsonConvert.SerializeObject(chartPoints);
//            return View();
//        }

//        public ActionResult MaxVelocityChart(int? vId)
//        {
//            List<DataPoint> chartPoints = new List<DataPoint>();
//            try
//            {
//                foreach (var item in _context.Vehicles.Find(vId).Statistics)
//                {
//                    chartPoints.Add(new DataPoint(item.RecordTime, item.MaxVelocity));
//                }
//            }
//            catch (Exception) { }
//            ViewBag.DataPoints = JsonConvert.SerializeObject(chartPoints);
//            return View();
//        }
//    }
//}

