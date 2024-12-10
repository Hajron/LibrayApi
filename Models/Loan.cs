using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models;

public class Loan
{
    public int Id { get; set;}

    [Required]
    [ForeignKey("Book")]
    public int BookId { get; set;} // Fremmednøkkel
    public Book book { get; set;}

    public DateTime LoadDate { get; set;} = DateTime.Now;
    public DateTime? ReturnDate { get; set;}

}