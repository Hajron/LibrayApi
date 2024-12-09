using LibraryApi.Models;

public interface IBooksService
{
    IEnumerable<Book> GetBooks();        // Hente alle bøker
    Book? GetBook(int id);                // Hente en bok basert på Id
    void CreateBook(Book book);          // Legge til en bok
    void UpdateBook(int id, Book book);  // Oppdatere en bok basert på Id
    void DeleteBook(int id);             // Slette bok basert på Id
}
