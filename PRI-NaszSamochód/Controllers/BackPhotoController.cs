using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PRI_NaszSamochód.Controllers
{
    public class BackPhotoController : Controller
    {
        [System.Web.Mvc.Route("BackPhoto/{userId}")]
        [System.Web.Mvc.HttpGet]
        public ActionResult Index(String userId)
        {
            Debug.WriteLine(User.Identity.GetUserId());
            var dir = Server.MapPath("~/BackGroundPhoto");
            var path = Path.Combine(dir, userId + ".jpg");
            Debug.WriteLine(userId);
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
                var fileSavePath = Path.Combine(Server.MapPath("~/BackGroundPhoto"), User.Identity.GetUserId() + ".jpg");

                // Save the uploaded file to "UploadedFiles" folder
                httpPostedFile.SaveAs(fileSavePath);
            }

        }
    }
}