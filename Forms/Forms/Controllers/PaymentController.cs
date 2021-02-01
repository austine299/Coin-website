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
    public class PaymentController : Controller
    {
        private UserFormEntities4 db = new UserFormEntities4();

        // GET: Payment
      

        // GET: Payment/Edit/5
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

        // POST: Payment/Edit/5
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
    }
}
