using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace artgallery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult shop()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult blog()
        {
            ViewBag.Message = "Your contact page.";

            return View();
    
        }

        public ActionResult home()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        public ActionResult Gallery()
        {
            ViewBag.Message = "Your Gallery page.";

            return View();
        }

        public ActionResult AuctionBlog()
        {
            return View();
        }


    }


}