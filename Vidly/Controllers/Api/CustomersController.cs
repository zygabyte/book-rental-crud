﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Data.Entity;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET Actions
        // gets all customers - GET api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDTOs = customersQuery.ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);

            return Ok(customerDTOs);
        }
        
        // gets a specific customerDTO - GET api/customers/:id
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
             
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer)); // mapping from the passed in customerDTO to the dto
        }

        // POST Actions
        // post a new customerDTO - POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) // form is not valid
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            // save changes has an id generated by the database and tacked unto the customerDTO.. 
            // so we want to include that ID in the our DTO too
            customerDTO.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
//            return customerDTO; // returns the new customerDTO with an ID property now.
        }

        // PUT Actions
        // update an existing customerDTO - PUT api/customers/:id
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) // form is not valid
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDTO, customerInDb); // we are passing the target object as the second argument. this is so that changes made to it are track by our context
            
            _context.SaveChanges();
            return Ok();
        }

        // DELETE Actions
        // delete an existing customerDTO - DELETE api/customers/:id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
        
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
