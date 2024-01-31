using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalPro.Models;

namespace FinalPro.Controllers
{
    public class AppointmentsController : Controller
    {
        private PropertyManagementDBEntities db = new PropertyManagementDBEntities();

        // GET: Appointments
        public ActionResult Index()
        {

            var user = Session["User"] as User;
            var appointments = db.Appointments.Include(a => a.User).Include(a => a.User1);
            if (user.Role == "PotentialTenant" || user.Role == "PropertyManager")
            {
                var apt = db.Appointments.Where(x=>x.User.UserId==user.UserId|| x.User1.UserId == user.UserId).Include(a => a.User).Include(a => a.User1);
                
                return View(apt.ToList());
            }

            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.PropertyManagerId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name");
            ViewBag.PotentialTenantId = new SelectList(db.Users.Where(s => s.Role == "PotentialTenant"), "UserId", "name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentId,PotentialTenantId,PropertyManagerId,DateTime,Note")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PotentialTenantId = new SelectList(db.Users.Where(s => s.Role == "PotentialTenant"), "UserId", "name", appointment.PotentialTenantId);
            ViewBag.PropertyManagerId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name", appointment.PropertyManagerId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PotentialTenantId = new SelectList(db.Users.Where(s => s.Role == "PotentialTenant"), "UserId", "name", appointment.PotentialTenantId);
            ViewBag.PropertyManagerId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name", appointment.PropertyManagerId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentId,PotentialTenantId,PropertyManagerId,DateTime,Note")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PotentialTenantId = new SelectList(db.Users.Where(s => s.Role == "PotentialTenant"), "UserId", "name", appointment.PotentialTenantId);
            ViewBag.PropertyManagerId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name", appointment.PropertyManagerId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
