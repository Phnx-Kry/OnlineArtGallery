using artgallery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        [HttpPost]
        public ActionResult LoginAdmin(Adminbox ad)
        {
            Adminbox AdminAdd = db.Adminboxes.Where(x => x.adminEmail == ad.adminEmail && x.adminPassword == ad.adminPassword).FirstOrDefault();

            if (ad != null)
            {
                FormsAuthentication.SetAuthCookie(ad.adminEmail, false);
                var profileData = new Adminbox
                {
                    adminId = ad.adminId,
                    adminFirstName = ad.adminFirstName
                };

                this.Session["AdminProfile"] = profileData;
                Session["AdminId"] = ad.adminId;
                Session["AName"] = ad.adminFirstName + ad.adminLastName;
                return RedirectToAction("Account", "AdministrativeCorner");
            }
            else
            {
                ViewBag.error = "Invalid Username or id";
            }


            return View();
        }




        //Get: Administration/Account
        [Authorize]
        public ActionResult Account()  //Profile couldnot be uesd for some reason soo...
        {

            if (Session["AdminProfile"] == null)
            {
                return RedirectToAction("LoginAdmin");
            }
            return View();
        }

        public ActionResult MembersList()
        {
            

            return View();
        }






        public ActionResult AdMembersEdit(Nullable<int> id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Memberss = db.Members.Find(id);

            var getAdmins = db.Adminboxes.ToList();
            SelectList adminList = new SelectList(getAdmins, "adminId", "adminFirstName");
            ViewBag.getAdminList = adminList;

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


        //Admin Power below



        public ActionResult AddArtCategory()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddArtCategory(ArtCategory cat)
        {

            if (ModelState.IsValid)
            {

                db.ArtCategories.Add(cat);    // (Modelvar).().Add(value entered in parameters)

                if (db.SaveChanges() > 0) // 
                {
                    TempData["msg"] = "Category Created";
                    return RedirectToAction("Account");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
        

        public ActionResult AddAucCategory()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddAucCategory(AucCategory cat)
        {

            if (ModelState.IsValid)
            {

                db.AucCategories.Add(cat);    // (Modelvar).().Add(value entered in parameters)

                if (db.SaveChanges() > 0) // 
                {
                    TempData["msg"] = "Category Created";
                    return RedirectToAction("Account");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }



        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();

            return RedirectToAction("LoginAdmin");
        }









    }
}