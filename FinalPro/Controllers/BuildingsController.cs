﻿using System;
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

    public class BuildingsController : Controller
    {
        private PropertyManagementDBEntities db = new PropertyManagementDBEntities();

        // GET: Buildings
        public ActionResult Index()
        {
            var buildings = db.Buildings.Include(b => b.User).Include(b => b.User1);
            return View(buildings.ToList());
        }

        // GET: Buildings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // GET: Buildings/Create
        public ActionResult Create()
        {
            List<User> pm = db.Users.Where(s => s.Role == "PropertyManager").ToList();
            List<User> po = db.Users.Where(s => s.Role == "PropertyOwner").ToList();
            ViewBag.PropertyManagerId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name");
            ViewBag.PropertyOwnerId = new SelectList(db.Users.Where(s => s.Role == "PropertyOwner"), "UserId", "name");
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuildingId,PropertyOwnerId,PropertyManagerId,Address,City,Province,PostalCode,BuildingName,HasLaundry,HasParking,IncludeUtils,CloseToTransit,Description")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Buildings.Add(building);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyManagerId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name", building.PropertyManagerId);
            ViewBag.PropertyOwnerId = new SelectList(db.Users.Where(s => s.Role == "PropertyOwner"), "UserId", "name", building.PropertyOwnerId);
            return View(building);
        }

        // GET: Buildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyManagerId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name", building.PropertyManagerId);
            ViewBag.PropertyOwnerId = new SelectList(db.Users.Where(s => s.Role == "PropertyOwner"), "UserId", "name", building.PropertyOwnerId);
            return View(building);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuildingId,PropertyOwnerId,PropertyManagerId,Address,City,Province,PostalCode,BuildingName,HasLaundry,HasParking,IncludeUtils,CloseToTransit,Description")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Entry(building).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyManagerId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name", building.PropertyManagerId);
            ViewBag.PropertyOwnerId = new SelectList(db.Users.Where(s => s.Role == "PropertyOwner"), "UserId", "name", building.PropertyOwnerId);
            return View(building);
        }

        // GET: Buildings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Building building = db.Buildings.Find(id);
            db.Buildings.Remove(building);
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
