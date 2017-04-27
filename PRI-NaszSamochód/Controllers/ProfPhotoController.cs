using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PRI_NaszSamochód.Controllers
{   [System.Web.Mvc.Authorize]
    public class ProfPhotoController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ProfPhotoController() {
        }

        public ProfPhotoController(ApplicationSignInManager signInManager, ApplicationUserManager userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: ProfilePhoto
        [System.Web.Mvc.Route("ProfPhoto/{user}")]
        [System.Web.Mvc.HttpGet]

        public ActionResult Index(String user)
        {   
            Debug.WriteLine(User.Identity.GetUserId() );
            var dir = Server.MapPath("/ProfilePhoto");
            var path = Path.Combine(dir, user + ".jpg");
            Debug.WriteLine(user);
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
                    var fileSavePath = Path.Combine(Server.MapPath("~/ProfilePhoto"), User.Identity.Name + ".jpg");

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                }
            
        }



    }
}