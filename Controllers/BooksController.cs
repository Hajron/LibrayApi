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
            new Book { Id = 1, Title = "Bulls Eye", Author = "Camilla Colly", Year = 1960 }
        };
    }
}