using artgallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace artgallery.Controllers
{
    public class StoreController : Controller
    {

        OnlineArtGalleryEntities db = new OnlineArtGalleryEntities();
        // GET: Store
        public ActionResult Index()  //Read Page
        {
            return View();
        }
        // GET: Store/Upload
        public ActionResult Upload()  //create page
        {
            return View();
        }
        // GET: Store/Checkout
        public ActionResult Checkout()   //...
        {
            return View();
        }
    }
}