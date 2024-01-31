using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using FinalPro.Models;

namespace FinalPro.Controllers
{
    public class UsersController : Controller
    {
        private PropertyManagementDBEntities db = new PropertyManagementDBEntities();

        // GET: Users
        //[Authorize(Roles = "Administrator,PropertyOwner,PotentialTenant")]
        private List<SelectListItem> GetUserRoles()
        {
            return db.Roles.Select(r => new SelectListItem { Value = r.RoleName, Text = r.RoleName }).ToList();
        }
        public ActionResult Index()
        {

            var user = Session["User"] as User;
            var users = db.Users.Include(u => u.Role1);

            ViewBag.UserRoles = new SelectList(db.Roles, "RoleName", "RoleName", user.Role);

            if (user.Role == "PotentialTenant"||user.Role=="PropertyManager")
            {
                var u = db.Users.Find(user.UserId);
                List<User> temp = new List<User>();
                temp.Add(u);
                return View(temp);
            }
           
            return View(users.ToList());
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            Debug.WriteLine($"searchString: {searchString}");
            var user = Session["User"] as User;
            var users = db.Users.Include(u => u.Role1);

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(x => x.Role == searchString);
            }

            if (user.Role == "PotentialTenant" || user.Role == "PropertyManager")
            {
                var u = db.Users.Find(user.UserId);
                List<User> temp = new List<User>();
                temp.Add(u);
                return View("Index", temp);
            }

            ViewBag.UserRoles = new SelectList(db.Roles, "RoleName", "RoleName", user.Role);
            return View("Index", users.ToList());
        }


        //[Authorize(Roles = "Administrator,PropertyOwner,PotentialTenant")]
        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

       
        
        // GET: Users/Create

        //[Authorize(Roles = "Administrator,PropertyOwner")]
        public ActionResult Create()
        {
            ViewBag.Role = new SelectList(db.Roles, "RoleName", "RoleName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize(Roles = "Administrator,PropertyOwner")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Username,Password,FirstName,LastName,DOB,Email,Role")] User user)
        {
            var u = (User)Session["User"];

            if (u.Role == "PotentialTenant")
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Role = new SelectList(db.Roles, "RoleName", "RoleName", user.Role);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role = new SelectList(db.Roles, "RoleName", "RoleName", user.Role);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Username,Password,FirstName,LastName,DOB,Email,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role = new SelectList(db.Roles, "RoleName", "RoleName", user.Role);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
