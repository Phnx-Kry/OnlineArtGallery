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

        OnlineArtGalleryEntities2 db = new OnlineArtGalleryEntities2();
        // GET: Customer
        public ActionResult Index()
        {
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
        public ActionResult Register(Member memberadd)
        {

            if (ModelState.IsValid)
            {
                db.Members.Add(memberadd);

                

                if (db.SaveChanges()>0)
                {
                    TempData["msg"] = "Account Created \n SignIn to Continue";
                    return RedirectToAction("MemberLogin");
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

        [HttpGet]
        public ActionResult MemberLogin() // login authenticatin 2
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberLogin(Member m) // login authenticatin 2
        {

            Member membes = db.Members.Where(x => x.memberEmail == m.memberEmail && x.memberPassword == m.memberPassword).FirstOrDefault();


            if (membes != null)
            {
                FormsAuthentication.SetAuthCookie(m.memberEmail, false);
                var profileData = new Member
                {
                    memberId = m.memberId,
                    memberFirstName = m.memberFirstName
                };

                this.Session["UserProfile"] = profileData;
                Session["UserId"] = m.memberId;
                Session["UName"] = m.memberFirstName + m.memberLastName;
                return RedirectToAction("Account");
            }
            else
            {
                ViewBag.error = "Invalid Username or id";
            }

            return View();
        }


        [Authorize]
        public ActionResult Account()  // profile ViewRead Page
        {

            if (Session["UserProfile"] == null)
            {
                return RedirectToAction("MemberLogin");
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();

            return RedirectToAction("MemberLogin");
        }
    }
}