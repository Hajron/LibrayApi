
using LibraryApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using Serilog;
public class BooksService : IBooksService
{
    public static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Monster", Author = "Drew Mansion", Year = 1977 },
            new Book { Id = 2, Title = "Bulls Eye", Author = "Camilla Colly", Year = 1960 }
        };

    public IEnumerable<Book> GetBooks() => books;

    public Book? GetBook(int id) => books.FirstOrDefault(b => b.Id == id);

    public void CreateBook(Book book)
    {
        book.Id = books.Max(b => b.Id) + 1;
        books.Add(book);
        Log.Information($"Book added: {book.Title}");
    }

    public void UpdateBook(int id, Book updatedBook)
    {
        var book = GetBook(id);
        if (book == null) return ;

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.Year = updatedBook.Year;
        Log.Information($"Updated Book: {book.Title}");
    }

    public void DeleteBook(int id)
    {
        var book = GetBook(id);
        if(book != null) books.Remove(book);
    }
    
}