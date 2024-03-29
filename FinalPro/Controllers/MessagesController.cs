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
    public class MessagesController : Controller
    {
        private PropertyManagementDBEntities db = new PropertyManagementDBEntities();

        // GET: Messages
        public ActionResult Index()
        {
            var messages = db.Messages.Include(m => m.User).Include(m => m.User1);

            var user = Session["User"] as User;
            if (user.Role == "PotentialTenant" || user.Role == "PropertyManager")
            {
                var msgs = db.Messages.Where(x => x.User.UserId == user.UserId || x.User1.UserId == user.UserId).Include(a => a.User).Include(a => a.User1);

                return View(msgs.ToList());
            }


            return View(messages.ToList());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {

            //ViewBag.SenderId = new SelectList(db.Users, "UserId", "Username");

            ViewBag.ReceiverId = new SelectList(db.Users, "UserId", "name");

            var user = Session["User"] as User;
            if (user.Role == "PotentialTenant")
            {
                ViewBag.ReceiverId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name");
                
            }
            if (user.Role == "PropertyManager")
            {
                ViewBag.ReceiverId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager" || s.Role == "PotentialTenant"), "UserId", "name");

            }
            //ViewBag.ReceiverId = new SelectList(db.Users, "UserId", "name");
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageId,ReceiverId,DateTime,Message1")] Message message)
        {
            if (ModelState.IsValid)
            {
                User u = (User)Session["User"];
                message.SenderId = u.UserId ;
                message.DateTime = DateTime.Now;
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var user = Session["User"] as User;
            if (user.Role == "PotentialTenant")
            {
                ViewBag.ReceiverId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name");

            }
            if (user.Role == "PropertyManager")
            {
                ViewBag.ReceiverId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager" || s.Role == "PropertyOwner"), "UserId", "name");

            }

            //ViewBag.ReceiverId = new SelectList(db.Users, "UserId", "name", message.ReceiverId);
//            ViewBag.SenderId = new SelectList(db.Users, "UserId", "Username", message.SenderId);
            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }

            var user = Session["User"] as User;
            if (user.Role == "PotentialTenant")
            {
                ViewBag.ReceiverId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name");

            }
            if (user.Role == "PropertyManager")
            {
                ViewBag.ReceiverId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager" || s.Role == "PropertyOwner"), "UserId", "name");

            }

            /*ViewBag.ReceiverId = new SelectList(db.Users, "UserId", "name", message.ReceiverId);
            ViewBag.SenderId = new SelectList(db.Users, "UserId", "name", message.SenderId);*/
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageId,SenderId,ReceiverId,Message1")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            /*ViewBag.ReceiverId = new SelectList(db.Users, "UserId", "name", message.ReceiverId);
            ViewBag.SenderId = new SelectList(db.Users, "UserId", "name", message.SenderId);*/

            var user = Session["User"] as User;
            if (user.Role == "PotentialTenant")
            {
                ViewBag.ReceiverId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager"), "UserId", "name");

            }
            if (user.Role == "PropertyManager")
            {
                ViewBag.ReceiverId = new SelectList(db.Users.Where(s => s.Role == "PropertyManager" || s.Role == "PropertyOwner"), "UserId", "name");

            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
