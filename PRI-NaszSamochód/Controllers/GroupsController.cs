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
        public ActionResult AddNewGroup()
        {
            return View("AddNewGroup");
        }
        public ActionResult GroupHeader()
        {
            return View("GroupHeader");
        }
        

        //public ActionResult GroupHeader(int? id)
        //{
        //    if(id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GroupViewModel model = new GroupViewModel(_context.Groups.Find(id));
        //    return View();
        //}

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult GroupContent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel group = _context.Groups.Find(id);
            GroupViewModel gvm = new GroupViewModel(group);
            if (group == null)
            {
                return HttpNotFound();
            }
            //if (gvm.LatestPosts.Capacity != 0)
            //{
            //    return View(gvm);
            //}
            //gvm.LatestPosts.Add(new PostViewModel(new PostModel()));
            return View(gvm);
        }

        // GET: Groups/Details/5
        public ActionResult GroupDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel group = _context.Groups.Find(id);
            GroupViewModel gvm = new GroupViewModel(group);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(gvm);
        }

        // POST: Groups/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult AddNewGroup([FromBody]GroupModel group)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GroupModel model = group;
                    string userId = User.Identity.GetUserId();
                    ApplicationUser admin = _context.Users.Where(x => x.Id.Equals(userId)).FirstOrDefault();
                    model.Administrator = new AdministratorModel(admin);
                    //model.Administrator.IsAdmin = true;
                    _context.Groups.Add(model);
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
        public ActionResult EditGroup(int? id)
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
        public ActionResult EditGroup(int id, [Bind(Include = "Id, GroupName, Description, GroupTheme")]GroupModel model)
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
        public ActionResult DeleteGroup(int? id)
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
        [System.Web.Mvc.HttpDelete, System.Web.Mvc.ActionName("DeleteGroup")]
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

        ////////////////////////////////////////////////////////////////
        //////////////////// NEXT ONE IS GONNA BE //////////////////////
        //////////////////// USED IN THE MOBILE   //////////////////////
        ////////////////////////////////////////////////////////////////
        [System.Web.Mvc.HttpGet]
        public GroupViewModel MobileGroup(int? id)
        {
            if(id == null)
            {
                return new GroupViewModel(new GroupModel());
            }
            GroupModel model = _context.Groups.Find(id);
            if(model == null)
            {
                return new GroupViewModel(new GroupModel());
            }
            return new GroupViewModel(model);
        }
    }
}
