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
    public class DashboardController : Controller
    {
        private UserFormEntities4 db = new UserFormEntities4();

        // GET: Dashboard
        public ActionResult Index()
        {
            return View(db.RegistrationForms.ToList());
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationForm registrationForm = db.RegistrationForms.Find(id);
            if (registrationForm == null)
            {
                return HttpNotFound();
            }
            return View(registrationForm);
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,OtherName,InvestorEmail,Age,PhoneNumber,YearOfExperience,Password,Amount,Upload_Screenshort")] RegistrationForm registrationForm)
        {
            if (ModelState.IsValid)
            {
                db.RegistrationForms.Add(registrationForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registrationForm);
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationForm registrationForm = db.RegistrationForms.Find(id);
            if (registrationForm == null)
            {
                return HttpNotFound();
            }
            return View(registrationForm);
        }

        // POST: Dashboard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,OtherName,InvestorEmail,Age,PhoneNumber,YearOfExperience,Password,Amount,Upload_Screenshort")] RegistrationForm registrationForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrationForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registrationForm);
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationForm registrationForm = db.RegistrationForms.Find(id);
            if (registrationForm == null)
            {
                return HttpNotFound();
            }
            return View(registrationForm);
        }

        // POST: Dashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistrationForm registrationForm = db.RegistrationForms.Find(id);
            db.RegistrationForms.Remove(registrationForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
