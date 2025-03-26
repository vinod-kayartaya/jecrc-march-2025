using Microsoft.EntityFrameworkCore;
using QnA_WebAPI_Project.Model;

namespace QnA_WebAPI_Project.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
       public DbSet<Question> Questions { get; set; }
    }
}
