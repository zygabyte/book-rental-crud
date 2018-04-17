using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class BooksController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public BooksController()
        {
            this._context = new ApplicationDbContext();
        }

        public IHttpActionResult GetBooks(string query = null)
        {
            var booksQuery = _context.Books
                .Include(b => b.Category);

            //return Ok(_context.Books
            //    .Include(b => b.Category)
            //    .ToList()
            //    .Select(Mapper.Map<Book, BookDTO>));

            if (!String.IsNullOrWhiteSpace(query))
            {
                booksQuery.Where(b => (b.Name.Contains(query)) && (b.NumberInStock > 0));
            }

            var booksDTOs = booksQuery.ToList()
                .Select(Mapper.Map<Book, BookDTO>);

            return Ok(booksDTOs);

        }
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.Include(b => b.Category).SingleOrDefault(b => b.Id == id);

            if (book == null)
                return BadRequest();

            return Ok(Mapper.Map<Book, BookDTO>(book));
        }

        [HttpPost]
        public IHttpActionResult CreateBook(BookDTO bookDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var book = Mapper.Map<BookDTO, Book>(bookDto); // creates a new object (Book) after the mapping and stores that object (Book) in book
            _context.Books.Add(book);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + bookDto.Id), bookDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateBook(int Id, BookDTO bookDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var bookInDB = _context.Books.SingleOrDefault(b => b.Id == Id);
            if (bookInDB == null)
                return NotFound();

            Mapper.Map(bookDto, bookInDB);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteBook(int Id)
        {
            var bookInDB = _context.Books.SingleOrDefault(b => b.Id == Id);

            if (bookInDB == null)
                return NotFound();

            _context.Books.Remove(bookInDB);
            _context.SaveChanges();

            return Ok();
        }
    }
}
