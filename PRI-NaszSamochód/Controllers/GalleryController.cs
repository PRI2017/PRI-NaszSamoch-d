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
        UserGalleryModel gallery = ApplicationDbContext.Create().Galleries.Single(x => x.Id == galleryId);
        return View(gallery);
    }


    [System.Web.Mvc.Authorize]
    [System.Web.Mvc.HttpPost]
    [POST("Gallery/")]
    public ActionResult Add(string name)
    {
        var db = ApplicationDbContext.Create();
        ApplicationUser owner = db.Users.First(x => x.Id == User.Identity.GetUserId());
        UserGalleryModel model = new UserGalleryModel(name, owner);
        db.Galleries.Add(model);
        db.SaveChanges();
        return RedirectToAction("UserGallery", new { galleryId = model.Id });
    }
}
