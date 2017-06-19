using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using PRI_NaszSamochód.Models;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Net;

public class GalleryController : Controller
{

    [GET("Gallery/")]
    public ActionResult GetAll()
    {
        var db = ApplicationDbContext.Create();
        string id = User.Identity.GetUserId();
        //var a = db.Galleries.Where(x => x.Owner.Id == id).ToList();
        var a = (from g in db.Galleries.Include("Owner") where g.Owner.Id == id select g).ToList();
        UserGalleryViewModel all = new UserGalleryViewModel(a);
        return View(all);
    }

    [GET("Gallery/{userId}/{galleryId}")]
    public ActionResult UserGallery(string userId, int? galleryId)
    {
        if (galleryId == null)
        {
            return RedirectToAction("GetAll");
        }
        ViewBag.galleryId = galleryId;
        ViewBag.userId = userId;
        ApplicationDbContext db = ApplicationDbContext.Create();
        ApplicationUser user = db.Users.Single(x => x.Id == userId);
        UserGalleryModel gallery = db.Galleries.Single(x => x.Id == galleryId);
        return View(gallery);
    }


    [System.Web.Mvc.Authorize]
    [System.Web.Mvc.HttpPost]
    [POST("Gallery/")]
    public ActionResult Add([FromUri]string name)
    {
        var db = ApplicationDbContext.Create();
        string userId = User.Identity.GetUserId();
        ApplicationUser owner = db.Users.Where(x => x.Id == userId).FirstOrDefault();
        UserGalleryModel model = new UserGalleryModel(name, owner);
        db.Galleries.Add(model);
        db.SaveChanges();
        return RedirectToAction("UserGallery", new { galleryId = model.Id });
    }

    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        var db = ApplicationDbContext.Create();
        UserGalleryModel entity = db.Galleries.Find(id);
        db.Galleries.Remove(entity);
        db.SaveChanges();
        return RedirectToAction("GetAll");
    }
}