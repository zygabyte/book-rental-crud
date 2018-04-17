using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using Vidly.Utilities;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose (bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            if (User.IsInRole(Constant.CanManageMovies))
            {
            return View();
            }
            return View("ReadIndex");
        }

        [Authorize(Roles = Constant.CanManageMovies)]
        public ActionResult New()
        {
            var customerViewModel = new CustomerViewModel
            {
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View("CustomerForm", customerViewModel);
        }

        [Authorize(Roles = Constant.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var customerViewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View("CustomerForm", customerViewModel);
        }

        [Authorize(Roles = Constant.CanManageMovies)]
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer); // not yet persisted to the database. currently in memory
            }
            else // we want to first retreive from DB so we can track changes and then store back
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // do not use this. it is not save, as malicious data could be sent into the db, while updating. and this is what microsoft recommends
                // TryUpdateModel(customerInDb);

                // an auto mapper could be used here though (3rd party conventional based mapping.. but u have to first create an intermediate model that will be used
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewletter = customer.IsSubscribedToNewletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }
//            this passed customer is automatically mapped from the submitted form
            _context.SaveChanges(); // db context goes through all sort of modifications, generate sql statements and then run them in a transaction
            return RedirectToAction("Index", "Customers");
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }
        
    }
}