    using artgallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Web.Security;

namespace artgallery.Controllers
{
    public class CustomerController : Controller
    {

        OnlineArtGalleryEntities db = new OnlineArtGalleryEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MemberLogin() // login authenticatin 2
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberLogin(Member m) // login authenticatin 2
        {

            var membes = db.Members.Where(x => x.memberEmail == m.memberEmail && x.memberPassword == m.memberPassword).FirstOrDefault();


            if (membes != null)
            {
                FormsAuthentication.SetAuthCookie(m.memberEmail, false);
                var profileData = new Member
                {
                    memberId = m.memberId,
                    memberFirstName = m.memberFirstName
                };

                this.Session["UserProfile"] = profileData;
                return RedirectToAction("Account");
                }
            else
            {
                ViewBag.error = "Invalid Username or id";
            }
            
            return View();
        }

        public ActionResult Register() // create page
        {
            /*var getAdmins = db.Adminboxes.ToList();
            SelectList adminList = new SelectList(getAdmins, "adminId", "adminFirstName");
            ViewBag.getAdminList = adminList;*/
            return View();
        }

        [HttpPost]
        public ActionResult Register(Member memberd)
        {

            if (ModelState.IsValid)
            {
                db.Members.Add(memberd);

                

                if (db.SaveChanges() > 0)
                {
                    TempData["msg"] = "Data Inserted";
                    return RedirectToAction("Account");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

            
        }
        [Authorize]
        public ActionResult Account()  // profile ViewRead Page
        {
            var profileData = this.Session["UserProfile"] as Member;
            

            return View();
        }

        
    }
}