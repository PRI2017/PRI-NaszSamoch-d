using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRI_NaszSamochód.Migrations;
using PRI_NaszSamochód.Models;
using System.IO;
using System.Text;
using AttributeRouting.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PRI_NaszSamochód.Controllers
{
    public class GalleryPhotoController : Controller
    {
        // GET: GalleryPhoto
        [GET("/{userId}/{galleryId}/{photoId}")]
        public ActionResult GetPhoto(string userId, int galleryId, int photoId)
        {
            UserGalleryModel gallery = ApplicationDbContext.Create().Galleries
                .First(g => g.Owner.Id == userId && g.Id == galleryId);
            var pathbulider = new StringBuilder("~/Galleries/");
            var dir = Server.MapPath(pathbulider.Append(userId).Append("/").Append(galleryId).ToString());
            var path = Path.Combine(dir, gallery.PhotosList.Where(x=>x.Id == photoId).Single().Path);
            Debug.WriteLine(path);
            return base.File(path, "image/jpeg");
        }

        [POST("GalleryPhoto/{galleryId}")]
        public void Upload(int galleryId)
        {
            var db = ApplicationDbContext.Create();
            var id = User.Identity.GetUserId();
            UserGalleryModel gallery =
                db.Galleries.First(g => g.Owner.Id == id && g.Id == galleryId);
            var pathbulider = new StringBuilder("~/Galleries/");
            var dir = Server.MapPath(pathbulider.Append(User.Identity.GetUserId()).Append("/")
                .Append(galleryId).ToString());

            var httpPostedFiles = HttpContext.Request.Files;



            var args = httpPostedFiles.AllKeys;
            for (int i = 0; i < args.Length; i++)
            {
                var httpPostedFile = httpPostedFiles[i];
                if (httpPostedFile != null)
                {
                    // If the directory does not exist, create it
                    var path = new StringBuilder("~/Galleries/");
                    Directory.CreateDirectory(Server.MapPath(path.Append(User.Identity.GetUserId()).Append("/").Append(galleryId).ToString()));

                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileSavePath = Path.Combine(dir, Path.GetRandomFileName() + ".jpg");

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                    gallery.PhotosList.Add(new PhotoModel(fileSavePath));
                }

            }
            db.SaveChanges();

        }
    }
}