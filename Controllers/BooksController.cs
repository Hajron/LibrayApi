using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;       // Dette er dependency injection (kaller på servicen, injectes i controlleren)

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _booksService.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {   
            var book = _booksService.GetBook(id);
            if (book == null)
            {
                NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> CreateBook(Book newBook)
        {
            _booksService.CreateBook(newBook);
            return CreatedAtAction(nameof(CreateBook), new {newBook.Id, newBook});
        }

        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, Book updatedBook)
        {
            var existingBook = _booksService.GetBook(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            _booksService.UpdateBook(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteBook(int id)
        {
            _booksService.DeleteBook(id);
            return NoContent();
        }
    }
}