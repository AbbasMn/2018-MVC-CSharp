using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class RoleNames
    {
        // MVC: declare Role Name as constants, prevent from dirty code and repetitive name changing
        public const string CanGetCustomer = "CanGetCustomer";
        public const string CanDetailCustomer = "CanDetailCustomer";
        public const string CanCreateCustomer = "CanCreateCustomer";
        public const string CanUpdateCustomer = "CanUpdateCustomer";
        public const string CanDeleteCustomer = "CanDeleteCustomer";
    }
}