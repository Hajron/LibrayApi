
using LibraryApi.Models;
using LibraryApi.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using Serilog;
public class BooksService : IBooksService
{
    private readonly IBookRepository _bookRepository;

    public BooksService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public IEnumerable<Book> GetBooks() => _bookRepository.GetBooks();

    public Book? GetBook(int id) => _bookRepository.GetBook(id);

    public void CreateBook(Book book)
    {
        if(book == null)
        _bookRepository.CreateBook(book);
        Log.Information($"Book added: {book.Title}");
    }

    public void UpdateBook(int id, Book updatedBook)
    {
        var book = GetBook(id);
        if (book == null) return ;

        _bookRepository.UpdateBook(book);
        Log.Information($"Updated Book: {book.Title}");
    }

    public void DeleteBook(int id)
    {
       _bookRepository.DeleteBook(id);
    }
    
}