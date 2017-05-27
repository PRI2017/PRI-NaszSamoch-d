using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using PRI_NaszSamochód.Models;

    public class GalleryController : Controller
    {
        [GET("Gallery/{galleryId}")]
        public ActionResult Index(int galleryId)
        {
            return View();
        }


    
    [System.Web.Mvc.HttpPost]
    [POST("Gallery/")]
    public void Add()
        {


        }
    }
