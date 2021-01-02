using artgallery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace artgallery.Controllers
{
    public class AuctionGalleryController : Controller
    {

        OnlineArtGalleryEntities db = new OnlineArtGalleryEntities();
        // GET: AuctionGallery
        public ActionResult Index()
        {


            return View();
        }

        //get: AuctionGallery/Upload
        [Authorize]
        public ActionResult Upload()
        {

            if (Session["UserProfile"] == null)
            {
                return RedirectToAction("MemberLogin", "Customer");

            }
            var getAdmins = db.Adminboxes.ToList();
            SelectList adminList = new SelectList(getAdmins, "adminId", "adminFirstName");
            ViewBag.getAdminList = adminList;

            var getArtist = db.Members.ToList();
            SelectList artistList = new SelectList(getArtist, "memberId", "memberFirstName");
            ViewBag.getArtistList = artistList;
            return View();
        }
        [HttpPost]
        public ActionResult Upload(AuctionGallery pics, HttpPostedFileBase imgfile)
        
        {




                string path = uploadimage(imgfile);

                if (path.Equals("-1"))
                {
                    ViewBag.error = "image could not be uploaded";

                }
                else
                {
                    AuctionGallery gal = new AuctionGallery();
                    gal.AucTitle = pics.AucTitle;
                    gal.AucDescription = pics.AucDescription;
                    gal.Currentbid = pics.Currentbid;
                    gal.AucCategory = pics.AucCategory;
                    gal.AucPic = path;//ssasa
                    gal.IsSold = false;
                    gal.EndingDate = pics.EndingDate;
                    
                    gal.DateUploaded = pics.DateUploaded;    //DateTime.Now;
                    gal.ArtistId_FK = Convert.ToInt32(Session["UserId"].ToString());  //sessionid

                    db.AuctionGalleries.Add(gal);
                    db.SaveChanges();

                    Response.Redirect("Index");
                }



                /*if (ModelState.IsValid)
                {
                    db.AuctionGalleries.Add(pics);
                    if (db.SaveChanges() > 0)
                    {
                        TempData["msg"] = "Pic Uploaded";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }*/
                return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }









        public string uploadimage(HttpPostedFileBase file)

        {

            Random r = new Random();

            string path = "-1";

            int random = r.Next();

            if (file != null && file.ContentLength > 0)

            {

                string extension = Path.GetExtension(file.FileName);

                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))

                {
                    try

                    {



                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));

                        file.SaveAs(path);

                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);



                        //    ViewBag.Message = "File uploaded successfully";

                    }

                    catch (Exception)

                    {

                        path = "-1";

                    }

                }

                else

                {

                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");

                }

            }



            else

            {

                Response.Write("<script>alert('Please select a file'); </script>");

                path = "-1";

            }







            return path;


        }




    }
}