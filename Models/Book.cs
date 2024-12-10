using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models;
public class Book
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Tittel er påkrevd")]
    [StringLength(100, ErrorMessage = "Tittel kan ikke være mere enn 100 tegn")]
    public string Title { get; set; }

    [Range(1910, 2024, ErrorMessage = "Året må være mellom 1910 og 2024!")]
    public int Year { get; set; }

    [ForeignKey("Author")]
    public int AuthorId { get; set; } //fremmednøkkel
    public Author Author { get; set; }

    public ICollection<Loan> Loans { get; set; }

}