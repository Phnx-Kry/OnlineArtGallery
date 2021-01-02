using artgallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace artgallery.Controllers
{
    public class AdministrativeCornerController : Controller
    {

        OnlineArtGalleryEntities db = new OnlineArtGalleryEntities();
        // GET: AdministrativeCorner
        public ActionResult Index()
        {
            return View();
        }

        // Get: Administation/Login
        public ActionResult LoginAdmin()
        {
            return View();
        }

        //Get: Administration/Account
        public ActionResult Account()  //Profile couldnot be uesd for some reason soo...
        {
            return View();
        }

        public ActionResult MembersList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Memberss = db.Members.Find(id);

            if (Memberss == null)
            {
                return HttpNotFound();
            }



            return View(Memberss);
           
        }



        public ActionResult AdminCreation()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AdminCreation(Adminbox admin)
        {

            if (ModelState.IsValid)
            {

                db.Adminboxes.Add(admin);    // (Modelvar).().Add(value entered in parameters)

                if (db.SaveChanges() > 0) // 
                {
                    TempData["msg"] = "ID Created";
                    return RedirectToAction("LoginAdmin");
                }
                else
                {
                    return View();
                }
            }

            return View();
        }

    }
}