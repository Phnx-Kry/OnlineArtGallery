using artgallery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace artgallery.Controllers
{
    public class SimpleArtGalleryController : Controller
    {
        OnlineArtGalleryEntities2 db = new OnlineArtGalleryEntities2();
        // GET: SimpleArtGallery
        public ActionResult Index()
        {
            List<ArtCategory> getCategry = db.ArtCategories.ToList();
            SelectList categoryList = new SelectList(getCategry, "cat_Id", "cat_name");
            ViewBag.categorylist = categoryList;



            return View(db.ArtGalleries.ToList());
        }


        //get: SimpleArtGallery/Upload
        [Authorize]
        [HttpGet]
        public ActionResult Upload()
        {


            if (Session["UserProfile"] == null)
            {
                return RedirectToAction("MemberLogin", "Customer");

            }
            else {

                List<ArtCategory> getCategry = db.ArtCategories.ToList();
                SelectList categoryList = new SelectList(getCategry, "cat_Id", "cat_name");
                ViewBag.categorylist = categoryList;

                var getAdmins = db.Adminboxes.ToList();
            SelectList adminList = new SelectList(getAdmins, "adminId", "adminFirstName");
            ViewBag.getAdminList = adminList;

            var getArtist = db.Members.ToList();
            SelectList artistList = new SelectList(getArtist, "memberId", "memberFirstName");
            ViewBag.getArtistList = artistList;

            return View();
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase imgfile, ArtGallery pics)
        {
            /*
                        string filename = Path.GetFileName(file.FileName);
                        string _filename = DateTime.Now.ToString("yymmssff") + filename;

                        string path = Path.Combine(Server.MapPath("~/Content/Data"), _filename);

                        pics.ArtPic = "~/Content/Data" + _filename;

                        db.ArtGalleries.Add(pics);

                        if (db.SaveChanges()>0)
                        {
                            file.SaveAs(path);
                            ViewBag.msg = "Picture Added to GAllery";
                            ModelState.Clear();
                        }
            */


            string path = Uploadimage(imgfile);



            if (path.Equals("-1"))
            {
                ViewBag.error = "image could not be uploaded";

            }
            else
            {
                ArtGallery gal = new ArtGallery();
                gal.ArtTitle = pics.ArtTitle;
                gal.ArtDescription = pics.ArtDescription;
                gal.ArtPrice = pics.ArtPrice;
                gal.ArtCategory = pics.ArtCategory;
                gal.ArtPic = path;//ssasa
                gal.IsSold = false;
                gal.approvalDate = pics.approvalDate;    //DateTime.Now;
                gal.artistId_FK = Convert.ToInt32(Session["UserId"].ToString());  //sessionid

                db.ArtGalleries.Add(gal);
                db.SaveChanges();

                ViewBag.msg = "Pic Uploaded Sucessfully";


                Response.Redirect("Index");
            }

            /*if (ModelState.IsValid)
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
            }*/
            return RedirectToAction("Upload");
        }

        public ActionResult CheckoutArt() //create of ArtInvice
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckoutArt(ArtInvoice invc) //create of AucInvice
        {
            if (ModelState.IsValid)
            {
                db.ArtInvoices.Add(invc);                                             // (Modelvar).().Add(value entered in parameters)

                if ((db.SaveChanges()) > 0) // 
                {
                    TempData["msg"] = "Invoice Updated";
                    return RedirectToAction("CustomersIndex");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }


        public string Uploadimage(HttpPostedFileBase imgfile)

        {
            
            Random r = new Random();

            string path = "-1";

            int random = r.Next();

            if (imgfile != null && imgfile.ContentLength > 0)

            {

                string extension = Path.GetExtension(imgfile.FileName);

                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))

                {
                    try

                    {



                        path = Path.Combine(Server.MapPath("~/Content/Data/"), random + Path.GetFileName(imgfile.FileName));

                        imgfile.SaveAs(path);

                        path = "~/Content/Data/" + random + Path.GetFileName(imgfile.FileName);



                        //    ViewBag.Message = "File uploaded successfully";

                    }

                    catch (Exception ex)

                    {
                        ViewBag.error2 = ex;/// nothing just removing error
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