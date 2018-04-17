using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
//        private ApplicationDbContext _context;
//        public MoviesController()
//        {
//            _context = new ApplicationDbContext();
//        }
//        // GET: Books
//        public ActionResult Index()
//        {
////            var movies = _context.Books.Include(c => c.Genre).ToList();
////            var viewModel = new BooksCustomers
////            {
////                Books = movies
////            };
////            
//            return View();
//        }
//
//        public ActionResult Random () { 
//            return View(new Movie() { Name = "Die Hard"});
//        }
//
//        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
//        public ActionResult ByReleasedDate(int year, int month)
//        {
//            return Content(year + "/" + month);
//        }
//
//        public ActionResult New()
//        {
//            var viewModel = new BooksCustomers
//            {
//                Categories = _context.Genres.ToList()
//            };
//
//            return View("MovieForm", viewModel);
//        }
//
//        public ActionResult Edit(int id)
//        {
//            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
//            var viewModel = new BooksCustomers
//            {
//                Book = movie,
//                Categories = _context.Genres.ToList()
//            };
//            return View("MovieForm", viewModel);
//        }
//
//        [HttpPost]
//        public ActionResult Save(Movie movie)
//        {
//            if (movie.Id == 0)
//            {
//                _context.Movies.Add(movie); // not yet persisted to the database. currently in memory
//            }
//            else // we want to first retreive from DB so we can track changes and then store back
//            {
//                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
//
//                // do not use this. it is not save, as malicious data could be sent into the db, while updating. and this is what microsoft recommends
//                // TryUpdateModel(customerInDb);
//
//                // an auto mapper could be used here though (3rd party conventional based mapping.. but u have to first create an intermediate model that will be used
//                movieInDb.Name = movie.Name;
//                movieInDb.DateAdded = movie.DateAdded;
//                movieInDb.NumberInStock = movie.NumberInStock;
//                movieInDb.ReleaseDate = movie.ReleaseDate;
//                movieInDb.GenreId = movie.GenreId;
//            }
////            this passed movie is automatically mapped from the submitted form
//            _context.SaveChanges(); // db context goes through all sort of modifications, generate sql statements and then run them in a transaction
//            return RedirectToAction("Index", "Movies");
//        }

    }
}