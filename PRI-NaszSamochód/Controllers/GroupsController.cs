using PRI_NaszSamochód.Models;
using PRI_NaszSamochód.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRI_NaszSamochód.Controllers
{
    public class GroupsController : Controller
    {

        private readonly NSDbContext _context;

        public GroupsController(NSDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GroupModel> Groups()
        {
            return _context.Groups.ToList();
        }

        // GET: Groups
        public ActionResult Index()
        {
            return View();
        }

        // GET: Groups/Details/5
        public GroupModel Details(int id)
        {
            GroupModel model = _context.Groups.Where(x => x.Id == id).Single();
            if (model.Equals(null))
            {
                return new GroupModel();
            }
            return model;
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Groups/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Groups/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
