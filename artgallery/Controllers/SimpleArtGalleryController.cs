using artgallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace artgallery.Controllers
{
    public class SimpleArtGalleryController : Controller
    {
        OnlineArtGalleryEntities db = new OnlineArtGalleryEntities();
        // GET: SimpleArtGallery
        public ActionResult Index()
        {
            return View();
        }


        //get: SimpleArtGallery/Upload
        [Authorize]
        public ActionResult Upload()
        {
            var getAdmins = db.Adminboxes.ToList();
            SelectList adminList = new SelectList(getAdmins, "adminId", "adminFirstName");
            ViewBag.getAdminList = adminList;

            var getArtist = db.Members.ToList();
            SelectList artistList = new SelectList(getArtist, "memberId", "memberFirstName");
            ViewBag.getArtistList = artistList;
            return View();
        }
        [HttpPost]
        public ActionResult Upload(ArtGallery pics)
        {
            if (ModelState.IsValid)
            {
                db.ArtGalleries.Add(pics);
                if (db.SaveChanges() > 0)
                {
                    TempData["msg"] = "Pic Uploaded";
                    return RedirectToAction("Index");
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