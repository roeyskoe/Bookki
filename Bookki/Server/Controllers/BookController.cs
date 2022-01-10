using Microsoft.AspNetCore.Mvc;
using Bookki.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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

        /// <summary>
        /// Lists all existing books
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public IEnumerable<Book> GetAll()
        {
            return books.Books;
        }

        /// <summary>
        /// Saves a completely new book
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        [HttpPost("save")]
        public IActionResult SaveNewBook(Book newBook)
        {
            // Never trust the guid client sends.
            newBook.Guid = Guid.NewGuid();
            books.Books.Add(newBook);

            return Ok(newBook);
        }

        /// <summary>
        /// Edits already existing book
        /// </summary>
        /// <param name="editedBook"></param>
        /// <returns></returns>
        [HttpPost("edit")]
        public IActionResult EditBook(Book editedBook)
        {
            Book book = books.Books.Find(b => b.Guid.Equals(editedBook.Guid));
            if (book is not null)
            {
                book.Name = editedBook.Name;
                book.Description = editedBook.Description;
                book.Author = editedBook.Author;
            }
            else
            {
                BadRequest("Specified book was not found.");
            }

            return Ok(editedBook);
        }

        /// <summary>
        /// Removes a book with the specified guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpDelete("delete/{guid}")]
        public IActionResult RemoveBook([FromRoute] Guid guid)
        {
            books.Books.RemoveAll((b)=>b.Guid.Equals(guid));
            // TODO: Error handling
            return Ok();
        }
    }
}
