using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC.Models;
using MVC.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace MVC.Controllers.Api
{
    public class CustomersController : ApiController
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
            // base.Dispose(disposing);  // MVC: delete this line !
            _context.Dispose();
        }
        #endregion

        ///////////////////////////



        // MVC: GET /api/customers
        //[Authorize(Roles = Models.RoleNames.CanGetCustomer)]
        public IEnumerable<CustomerDto> GetCustomers()  // MVC: IEnumerable<Customer> to IEnumerable<CustomerDto> for Dto implementation
        {
            // return _context.Customers.ToList().Select(Mapper.Map <Customer, CustomerDto>);  // MVC: return _context.Customers.ToList();

            return _context.Customers
                .Include(c => c.MembershipType)     // MVC: for see customer membershipType
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>); 
        }






        // MVC: GET /api/customers/1
        //[Authorize(Roles = Models.RoleNames.CanDetailCustomer)]
        public IHttpActionResult GetCustomer(int id)     // MVC: public Customer GetCustomer(int? id) replaced, for Dto implementation -> // MVC: public CustomerDto GetCustomer(int? id) 
        {
            var cust = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (cust == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Customer, CustomerDto>(cust));  // return cust;  replaced, for Dto implementation -> // return Mapper.Map<Customer, CustomerDto>(cust);
        }






        // MVC: POST /api/customers
        [HttpPost]
        //[Authorize(Roles = Models.RoleNames.CanCreateCustomer)] // MVC: we dont need to declare [HttpPost] here regarding microsoft official website if name: PostCustomer -> // MVC: public Customer PostCustomer(Customer customer)
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)    // MVC: public Customer GetCustomer(int? id) replaced, for Dto implementation   -> // MVC: public CustomerDto CreateCustomer(CustomerDto customerDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest ();  // for return data type: IHttpActionResult
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cust = Mapper.Map <CustomerDto, Customer>(customerDto);    // add for Dto

            _context.Customers.Add(cust);
            _context.SaveChanges();

            customerDto.Id = cust.Id;

            return Created(new Uri(Request.RequestUri+"/"+cust.Id), customerDto); // add for URI
            //return customerDto;  
        }






        // MVC: PUT /api/customers/1
        [HttpPut]
        //[Authorize(Roles = Models.RoleNames.CanUpdateCustomer)]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var custInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (custInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map<CustomerDto, Customer>(customerDto, custInDb);

            //custInDb.Name = customerDto.Name;
            //custInDb.Family= customerDto.Family;
            //custInDb.Birthdate = customerDto.Birthdate;
            //custInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            //custInDb.Name = customerDto.Name;

            _context.SaveChanges();
        }







        // MVC: DELETE /api/customers/1
        [HttpDelete]
        //[Authorize(Roles = Models.RoleNames.CanDeleteCustomer)]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var custInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (custInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(custInDb);
            _context.SaveChanges();
        }

    }
}
