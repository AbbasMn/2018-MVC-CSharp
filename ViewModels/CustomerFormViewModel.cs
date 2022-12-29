using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.ViewModels
{
    public class CustomerFormViewModel
    {
        // MVC: define aview model for customer registration form information
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}