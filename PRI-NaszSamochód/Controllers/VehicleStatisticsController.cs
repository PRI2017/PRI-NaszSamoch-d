﻿using System;
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

        public ActionResult VehicleStatisticsHeader(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleStatisticsModel model = _context.Vehicles.Find(Id).Statistics;
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

        // POST: Groups/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Key, KilometersDriven, FuelUsed, MaxVelocity, RecordStartTime, RecordEndTime")]VehicleStatisticsModel model, int vehicleId)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Find(vehicleId).Statistics = model;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_context.Vehicles.Find(vehicleId).Statistics);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel group = _context.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        [System.Web.Mvc.HttpPut]
        public ActionResult Edit([Bind(Include = "Key, KilometersDriven, FuelUsed, MaxVelocity, RecordStartTime, RecordEndTime")]VehicleStatisticsModel model, int vehicleId)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Find(vehicleId).Statistics = model;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel group = _context.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [System.Web.Mvc.HttpDelete, System.Web.Mvc.ActionName("Delete")]
        public ActionResult DeleteConfirmed(int vehicleId)
        {
            VehicleModel model = _context.Vehicles.Find(vehicleId);
            if (model == null)
            {
                return HttpNotFound();
            }
            if (!(model.Statistics == null))
            {
                _context.Vehicles.Find(vehicleId).Statistics = null;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}