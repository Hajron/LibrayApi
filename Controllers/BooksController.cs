using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BooksController : ControllerBase
    {
        public static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Monster", Author = "Drew Mansion", Year = 1977 },
            new Book { Id = 2, Title = "Bulls Eye", Author = "Camilla Colly", Year = 1960 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {   
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> CreateBook(Book newBook)
        {
            newBook.Id = books.Max(b => b.Id) + 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(CreateBook), new {newBook.Id, newBook});
        }

        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, Book updatedBook)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NoContent();
            }
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Year = updatedBook.Year;

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteBook(int id)
        {
            var book = books.Find(b => b.Id == id);
            if(book == null)
            {
                return NotFound();
            }

            books.Remove(book);
            return NoContent();
        }
    }
}