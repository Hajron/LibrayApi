using LibraryApi.Models;

namespace LibraryApi.Repository
{
    public interface IBookRepository
    {
        IQueryable<Book> GetBooks();
        Book GetBook(int id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}