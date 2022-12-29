using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;
using MVC.Models;

namespace MVC.Controllers
{
    //[Authorize]     // MVC: apply authorization globally on project -> go to App_Start -> FilterConfig.cs -> 
    public class CustomersController : Controller
    {

        #region Database Quering Objects

        private ApplicationDbContext _context;

        // MVC: Constructor
        public CustomersController() 
        {
            // MVC: Disposable Object
            _context = new ApplicationDbContext();             
        }

        // MVC: Override base class's Dispose method
        protected override void Dispose(bool disposing)  
        {
            // MVC: base.Dispose(disposing);  // delete this line !
            _context.Dispose();
        }

        #endregion

        ///////////////////////////

        // MVC: Delete in the same Page 
        //[Authorize(Roles = RoleNames.CanDeleteCustomer)]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();
            else {
                var Cust = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (Cust == null)
                    return HttpNotFound();
                else
                {
                    _context.Customers.Remove(Cust);                   
                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return RedirectToAction("Index", "Customers");
                }
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SaveCustomer(Customer Customer) // MVC: (CustomerFormViewModel viewModel)  // MVC: CustomerFormViewModel class include Customer Class
        {
            // MVC object Validation regarding tha class dat annotations
            if (! ModelState.IsValid) // Object Model is not Valid
            {
                var errors = ModelState  // Get Model Validation Errors
                            .Where(x => x.Value.Errors.Count > 0)
                            .Select(x => new { x.Key, x.Value.Errors })
                            .ToArray();            

                var vm = new ViewModels.CustomerFormViewModel
                {
                    Customer = Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View ("CustomerForm", vm );
            }
            else    // Object Model is Valid
            {
                if (Customer.Id != 0) // Edit Customer
                {
                    var CustInDb = _context.Customers.Single(c => c.Id == Customer.Id);
                    //TryUpdateModel(CustInDb);  // don’t use this way => security hurts

                    CustInDb.Name = Customer.Name;
                    CustInDb.Family = Customer.Family;
                    CustInDb.Birthdate = Customer.Birthdate;
                    CustInDb.IsSubscribedToNewsletter = Customer.IsSubscribedToNewsletter;
                    CustInDb.MembershipTypeId = Customer.MembershipTypeId;

                    // Mappper.Map(Customer, CustInDb); // don’t use this way => security hurts as well

                }
                else  // Insert Customer
                    _context.Customers.Add(Customer);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return RedirectToAction("Index", "Customers");
            }
        }

        //[Authorize(Roles = Models.RoleNames.CanUpdateCustomer)]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();
            else {
                var Cust = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (Cust == null)
                    return HttpNotFound();
                else
                {
                    var vm = new ViewModels.CustomerFormViewModel
                    {
                        Customer = Cust,
                        MembershipTypes = _context.MembershipTypes.ToList()
                    };
                    return View("CustomerForm", vm);
                }
            }
        }


        //[Authorize(Roles = Models.RoleNames.CanCreateCustomer)]
        public ActionResult NewCustomer()
        {
            var MemTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                // add Customer = new Customer(), for prevent Model.IsValid == flase, because of @Html.HiddenFor(model => model.Customer.Id)
                // <input class="input-validation-error" data-val="true" data-val-number="The field Id must be a number." 
                // data-val-required="The Id field is required." id="Customer_Id" name="Customer.Id" type="hidden" value="">
                Customer = new Customer(),
                MembershipTypes = MemTypes
            };

            return View("CustomerForm", viewModel);
        }


        //[Authorize(Roles = Models.RoleNames.CanDetailCustomer)]
        public ActionResult Customer(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();
            else {
                var Cust = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
                if (Cust == null)
                    return HttpNotFound();
                else
                    return View(Cust);
            }

        }

        //[Authorize]        // MVC: use [Authorize] for all actin in this controller definition -> public class CustomersController : Controller
        //[Authorize(Roles = Models.RoleNames.CanGetCustomer)]
        // MVC: GET: Customers
        public ActionResult Index()
        {
            var allcust = new CustomersListViewModel();         
            allcust.AllCustomers = GetCustomerFromDatabase();   
            return View(allcust);                                                                                             
        }

        private List<Customer> GetCustomerFromDatabase()
        {
            // EF goes to database and Ececute Immediately
            //var customers1 = _context.Customers.ToList();

            var customers1 = _context.Customers.Include(c => c.MembershipType).ToList();


            // EF doesnt go to database (defferd execution => 
            //execute when ittrate over customer object with foreach (...) loop)
            //var customers2 = _context.Customers;  

            return customers1;
        }

        private List<Customer> GetCustomerByGenerateData()
        {
            return new List<Customer>
            {
                new Customer{ Id=1, Birthdate=DateTime.Parse("07/28/1982"), Name="Ali", Family ="Alavi",
                    MembershipTypeId=1,
                    IsSubscribedToNewsletter =false },

                new Customer{Id=2, Birthdate=DateTime.Parse("06/25/1982"), Name="Zahra", Family="Zohravi",                    
                    MembershipTypeId=2,
                    IsSubscribedToNewsletter =true }
            };
        }
    }
}