using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalPro.Controllers
{
    public static class RoleHelper
    {
        public static string PotentionalTenant { get; } = "PotentialTenant";
        public static string PropertyOwner { get; } = "PropertyOwner";
        public static string PropertyManager { get; } = "PropertyManager";
        public static string Administrator { get; } = "Administrator";
    }
}