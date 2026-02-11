
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MOON12\\SQLEXPRESS;Database=LibraryApp;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
