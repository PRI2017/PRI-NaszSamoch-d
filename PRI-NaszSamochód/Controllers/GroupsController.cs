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
                    _context.Groups.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("GroupDetails", new { id = model.Id });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }

        public ActionResult AddPostView()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public void AddPost(PostModel post, int? groupId)
        {
            using (var db = ApplicationDbContext.Create())
            {
                post.Added = DateTime.Now;
                post.Creator = db.Users.Find(User.Identity.GetUserId());
                db.Groups.Find(groupId).Posts.Add(post);
                db.SaveChanges();
            }
        }

        // GET: Groups/Edit/5
        public ActionResult EditGroup(int? id)
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser admin = _context.Users.Where(x => x.Id.Equals(userId)).FirstOrDefault();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel group = (from g in _context.Groups.Include("Administrator.User")
                                where g.Id == id
                                select g).FirstOrDefault();
            if (group == null)
            {
                return HttpNotFound();
            }
            if (group.Administrator.User.Id == admin.Id)
            {
                return View(group);
            }
            return RedirectToAction("NotAdmin");
        }

        // POST: Groups/Edit/5
        [System.Web.Mvc.HttpPut]
        public ActionResult EditGroup(int id, [FromBody]GroupModel model)
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser admin = _context.Users.Where(x => x.Id.Equals(userId)).FirstOrDefault();
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Administrator.User.Id == admin.Id)
                    {
                        _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        _context.SaveChanges();
                        return RedirectToAction("GroupDetails", new { id = model.Id });
                    }
                    else return RedirectToAction("NotAdmin");
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
            string userId = User.Identity.GetUserId();
            ApplicationUser admin = _context.Users.Where(x => x.Id.Equals(userId)).FirstOrDefault();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel group = (from g in _context.Groups.Include("Administrator.User")
                                where g.Id == id
                                select g).FirstOrDefault();
            if (group == null)
            {
                return HttpNotFound();
            }
            if (group.Administrator.User.Id == admin.Id)
                return View(group);
            else return RedirectToAction("NotAdmin");
        }

        // POST: Groups/Delete/5
        [System.Web.Mvc.HttpDelete, System.Web.Mvc.ActionName("DeleteGroup")]
        public ActionResult DeleteConfirmed(int id)
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser admin = _context.Users.Where(x => x.Id.Equals(userId)).FirstOrDefault();
            //GroupModel group = _context.Groups.Find(id);
            GroupModel group = (from g in _context.Groups.Include("Administrator.User")
                                where g.Id == id
                                select g).FirstOrDefault();
            if (group == null)
            {
                return HttpNotFound();
            }
            if (group.Administrator.User.Id == admin.Id)
            {
                _context.Groups.Remove(group);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("NotAdmin");
        }

        public ActionResult NotAdmin()
        {
            return View();
        }

        ////////////////////////////////////////////////////////////////
        //////////////////// NEXT ONE IS GONNA BE //////////////////////
        //////////////////// USED IN THE MOBILE   //////////////////////
        ////////////////////////////////////////////////////////////////
        [System.Web.Mvc.HttpGet]
        public JsonResult MobileGroup()
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser user = _context.Users.Where(x => x.Id.Equals(userId)).FirstOrDefault();
            List<GroupViewModel> modelsList = new List<GroupViewModel>();
            foreach (var i in _context.Groups.Where(g => g.Administrator.User.Id == userId).ToList())
            {
                modelsList.Add(new GroupViewModel(i));
            }
            return Json(modelsList, JsonRequestBehavior.AllowGet);
        }
    }
}
