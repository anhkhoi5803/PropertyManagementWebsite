using FinalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinalPro.Controllers
{
    public class WebAuth:AuthorizeAttribute
    {
        /*protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Check if the user is authenticated
            if (httpContext.Session["User"] != null)
                return false;

            var requiredRoles = Roles.Split(',');

            var user = httpContext.Session["UserRole"] as User;
            var userRole = user.Role;

            return requiredRoles.Contains(userRole);

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserId"] != null)
            {
                // Authenticated user without the required role
                // Redirect to the current page
                filterContext.Result = new RedirectResult(filterContext.HttpContext.Request.Url.PathAndQuery);
            }
            else
            {
                // Unauthorized user or not authenticated
                // Redirect to the login page
                filterContext.Result = new RedirectResult("~/Accounts/Login");
            }
        }*/

    }
}