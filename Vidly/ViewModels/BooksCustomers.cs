using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class BooksCustomers
    {
        public Book Book { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }


    }
}