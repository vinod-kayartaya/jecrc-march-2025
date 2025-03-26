using ConsoleAppWithEntityFrameworkAndMySQL.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppWithEntityFrameworkAndMySQL.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
