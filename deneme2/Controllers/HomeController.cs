using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using deneme2.Models;

namespace deneme2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                using (LoginDB_Entities db = new LoginDB_Entities())
                {
                    var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage");
            }
        }

        public ActionResult SessionPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SessionPage(string kullaniciAd, string kullaniciSifre)
        {
            Session["Kullanici"] = kullaniciAd;
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

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserProfile U)
        {
            if (ModelState.IsValid)
            {
                using (LoginDB_Entities dc = new LoginDB_Entities())
                {
                    dc.UserProfiles.Add(U);
                    dc.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Successfully Registration Done";
                }
            }
            return View(U);
        }
        //public ActionResult ProductList()
        //{
        //    return View();
        //}
        //[ValidateAntiForgeryToken]
        public ActionResult ProductList(Products pr)
        {
            try
            {
                using (var dbContext = new LoginDB_Entities())
                {
                    var data = dbContext.Products.Where(p => p.ProductId == 1).FirstOrDefault();

                    dbContext.Products.Remove(new Products());
                    dbContext.SaveChanges();
                }
                return View(pr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
