using Microsoft.AspNetCore.Mvc;
using Bookki.Shared;
using System.Collections.Generic;

namespace Bookki.Server.Controllers
{
    [ApiController]
    [Route("api")]
    public class BookController : Controller
    {
        private BookCollection books;

        public BookController(BookCollection _books)
        {
            books = _books;
        }

        [HttpGet("all")]
        public IEnumerable<Book> GetAll()
        {
            return books.Books;
        }
    }
}
