using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRI_NaszSamochód.Migrations;
using PRI_NaszSamochód.Models;
using System.IO;
using System.Text;
using Microsoft.AspNet.Identity;

namespace PRI_NaszSamochód.Controllers
{
    public class GalleryPhotoController : Controller
    {
        // GET: GalleryPhoto
       [ System.Web.Mvc.Route("GalleryPhoto/{userId}/{galleryId}/{photoId}")]
        public ActionResult GetPhoto(string userId, int galleryId, int photoId)
       {
        UserGalleryModel gallery = ApplicationDbContext.Create().Galleries.First(g => g.Owner.Id == userId && g.Id == galleryId);
           var pathbulider = new StringBuilder("Galleries/");
           var dir = Server.MapPath(pathbulider.Append(userId).Append("/").Append(galleryId).ToString());
           var path = Path.Combine(dir,photoId + ".jpg");
           Debug.WriteLine(path);
           return base.File(path, "image/jpeg");
        }
        [System.Web.Mvc.HttpPost]
        public void Upload()
        {


            // Get the uploaded image from the Files collection
            var httpPostedFile = HttpContext.Request.Files[0];

            if (httpPostedFile != null)
            {
                // Validate the uploaded image(optional)

                // Get the complete file path
                var fileSavePath = Path.Combine(Server.MapPath("~/ProfilePhoto"), User.Identity.GetUserId() + ".jpg");

                // Save the uploaded file to "UploadedFiles" folder
                httpPostedFile.SaveAs(fileSavePath);
            }

        }

    }
}