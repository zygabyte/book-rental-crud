using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Utilities;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;
        public BooksController()
        {
            this._context = new ApplicationDbContext();
        }

        // GET: Books
        public ActionResult Index()
        {
            if (User.IsInRole(Constant.CanManageMovies))
            {
                return View("Index");
            }
            return View("ReadIndex");
        }

        [Authorize(Roles = Constant.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new BooksCustomers()
            {
                Categories = _context.Categories.ToList()
            };
            return View("BookForm", viewModel);
        }

        [Authorize(Roles = Constant.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            var viewModel = new BooksCustomers
            {
                Book = book,
                Categories = _context.Categories.ToList()
            };
            return View("BookForm", viewModel);
        }

        [Authorize(Roles = Constant.CanManageMovies)]
        [HttpPost]
        public ActionResult Save(Book book)
        {
            if (book.Id == 0)
            {
                _context.Books.Add(book); // not yet persisted to the database. currently in memory
            }
            else // we want to first retreive from DB so we can track changes and then store back
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);

                // do not use this. it is not save, as malicious data could be sent into the db, while updating. and this is what microsoft recommends
                // TryUpdateModel(customerInDb);

                // an auto mapper could be used here though (3rd party conventional based mapping.. but u have to first create an intermediate model that will be used
                bookInDb.Name = book.Name;
                bookInDb.DateAdded = book.DateAdded;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.CategoryId = book.CategoryId;
            }
            //            this passed book is automatically mapped from the submitted form
            _context.SaveChanges(); // db context goes through all sort of modifications, generate sql statements and then run them in a transaction
            return RedirectToAction("Index", "Books");
        }
    }
}