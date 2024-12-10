
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data
{
    class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options){}

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relasjonen en forfatter kan skrive mange bøker
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(b => b.AuthorId);

            // Relasjon en bok kan ha mange lån
            modelBuilder.Entity<Book>()
                .HasMany(a => a.Loans)
                .WithOne(a => a.Book)
                .HasForeignKey(l => l.BookId);
        }


    }
}


