using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRI_NaszSamochód.Models;

    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }


    [System.Web.Mvc.Route("Gallery/{GalleryId}")]
    [System.Web.Mvc.HttpGet]
    public void Upload()
        {


        }
    }
