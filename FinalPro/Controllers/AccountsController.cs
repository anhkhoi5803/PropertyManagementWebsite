using FinalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;

namespace FinalPro.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            using (PropertyManagementDBEntities context = new PropertyManagementDBEntities())
            {
                bool isValidUser = context.Users.Any(user => user.Username==
                model.Username && user.Password == model.Password);

                if (isValidUser)
                {
                    var tempUser = context.Users.FirstOrDefault(user => user.Username == model.Username && user.Password == model.Password);


                    
                    
                    
                    Session["User"] = tempUser;
                    Session.Timeout = 5;

                    var role = tempUser.Role;
                    var name = (model.FirstName + " " + model.LastName);


                    var authTicket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddMinutes(3), false, role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

                    FormsAuthentication.SetAuthCookie(name, false);
                    //ool t = User.IsInRole(RoleHelper.PotentionalTenant);


                    return RedirectToAction("Index", "Users");
                }
                ModelState.AddModelError("", "Invalid username or password !"); return View();
            }
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User user)
        {
            using (PropertyManagementDBEntities context = new PropertyManagementDBEntities())
            {
                user.Role = "PotentialTenant";
                context.Users.Add(user);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            HttpContext.Session.Timeout = 01;
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}