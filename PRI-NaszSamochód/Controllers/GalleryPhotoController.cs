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
        [GET("GalleryPhoto/{userId}/{galleryId}/{photoId}")]
        public ActionResult GetPhoto(string userId, int galleryId, int photoId)
        {
            UserGalleryModel gallery = ApplicationDbContext.Create().Galleries
                .First(g => g.Owner.Id == userId && g.Id == galleryId);
            var pathbulider = new StringBuilder("Galleries/");
            var dir = Server.MapPath(pathbulider.Append(userId).Append("/").Append(galleryId).ToString());
            var path = Path.Combine(dir, photoId + ".jpg");
            Debug.WriteLine(path);
            return base.File(path, "image/jpeg");
        }

        [POST("GalleryPhoto/{galleryId}")]
        public void Upload(int galleryId)
        {
            var db = ApplicationDbContext.Create();
            UserGalleryModel gallery =
                db.Galleries.First(g => g.Owner.Id == User.Identity.GetUserId() && g.Id == galleryId);
            var pathbulider = new StringBuilder("Galleries/");
            var dir = Server.MapPath(pathbulider.Append(User.Identity.GetUserId()).Append("/")
                .Append(galleryId).ToString());

            var httpPostedFiles = HttpContext.Request.Files;



            var args = httpPostedFiles.AllKeys;
            for (int i = 0; i < args.Length; i++)
            {
                var httpPostedFile = httpPostedFiles[i];
                if (httpPostedFile != null)
                {
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