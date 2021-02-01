using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Forms.Models;

namespace Forms.Controllers
{
    public class HomeController : Controller
    {

        private UserFormEntities4 db = new UserFormEntities4();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,OtherName,InvestorEmail,Age,PhoneNumber,YearOfExperience,Password,Amount,Upload_Screenshort")] RegistrationForm register)
        {
            if (ModelState.IsValid)
            {
                db.RegistrationForms.Add(register);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            ViewBag.Message = "Thank you for Registering C4 BTC BOT / INVESTMENT ";
            return View(register);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAutherize(RegistrationForm userModel)
        {
            using (UserFormEntities4 dbuser = new UserFormEntities4())
            {
                var userDetail = dbuser.RegistrationForms.Where(x => x.InvestorEmail == userModel.InvestorEmail && x.Password == userModel.Password).FirstOrDefault();

                if (userDetail == null)
                {
                    userModel.LoginErrorMessage = "Wrong Email or passwprd";

                    return View("Login", userModel);
                }
                else
                {
                    Session["ID"] = userDetail.ID;
                    Session["FirstName"] = userDetail.FirstName;
                    Session["Amount"] = userDetail.Amount;
                    Session["Interest"] = userDetail.Amount/100*10;
                    Session["Total"] = userDetail.Amount+userDetail.Amount/100*10;
                    return RedirectToAction("Dashboard", "Home");
                }
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Dashboard()
        {
            return View();
        }

    }
}