using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.ViewModels
{
    public class CustomersListViewModel
    {
        public List<Customer> AllCustomers { get; set; }
    }
}