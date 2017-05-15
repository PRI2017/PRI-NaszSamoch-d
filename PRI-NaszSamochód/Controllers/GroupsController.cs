using Microsoft.AspNet.Identity;
using PRI_NaszSamochód.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace PRI_NaszSamochód.Controllers
{
    [System.Web.Mvc.Authorize]
    public class GroupsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public GroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Groups
        public ActionResult Index()
        {
            return RedirectToAction("GroupHeader");
        }

        public ActionResult GroupHeader(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupViewModel model = new GroupViewModel(_context.Groups.Find(id));
            return View();
        }

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult GroupContent()
        {
            return View();
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
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

        // POST: Groups/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create([Bind(Include = "Id, GroupName, Description, GroupTheme")]GroupModel group)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Groups.Add(group);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(group);
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
        public ActionResult Edit(int id, [Bind(Include = "Id, GroupName, Description, GroupTheme")]GroupModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
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
        public ActionResult DeleteConfirmed(int id)
        {
            GroupModel group = _context.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            _context.Groups.Remove(group);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
