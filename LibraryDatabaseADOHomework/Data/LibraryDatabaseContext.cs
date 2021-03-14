using EFCoreLibraryDatabaseHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLibraryDatabaseHomework.Data
{
    public class LibraryDatabaseContext : DbContext
    {
        public LibraryDatabaseContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Reader> Readers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<LendingBooks> LendingBooks { get; set; } 

        public DbSet<BooksAuthors> BooksAuthors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-619RM10; Database=LibraryDatabase; Trusted_Connection=True;");
        }
    }
}
