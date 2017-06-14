using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using PRI_NaszSamochód.Models;
using System.Web.Http;
using Microsoft.AspNet.Identity;

public class GalleryController : Controller
{
    [GET("Gallery/{galleryId}")]
    public ActionResult UserGallery(int galleryId)
    {
        ApplicationDbContext db = ApplicationDbContext.Create();
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
        ApplicationUser owner = db.Users.Where(x=>x.Id == userId).FirstOrDefault();
        UserGalleryModel model = new UserGalleryModel(name, owner);
        db.Galleries.Add(model);
        db.SaveChanges();
        return RedirectToAction("UserGallery", new { galleryId = model.Id });
    }
}
