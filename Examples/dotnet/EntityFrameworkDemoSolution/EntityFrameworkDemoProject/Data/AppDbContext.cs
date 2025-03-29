using EntityFrameworkDemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemoProject.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        // since this class represents a database, 
        // following DbSet properties represent tables in the database
        public DbSet<Employee> Employees { get; set; }

    }
}
