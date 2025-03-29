using Microsoft.EntityFrameworkCore;

namespace ConsoleAppWithEntityFrameworkAndMySQL.Data
{
    public static class DatabaseConfig
    {
        public static string ConnectionString => "Data Source=books.db";

        public static DbContextOptions<BookDbContext> GetDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookDbContext>();
            optionsBuilder.UseSqlite(ConnectionString);
            return optionsBuilder.Options;
        }
    }
} 