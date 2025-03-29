using EntityFrameworkDemoProject.Data;
using Microsoft.EntityFrameworkCore;

DbContextOptionsBuilder builder = new();
builder.UseSqlServer("Server=VINOD-HPP\\SQLEXPRESS;Database=jecrc_ef_demo;Integrated Security=True;TrustServerCertificate=True;");

AppDbContext context = new(builder.Options);
context.Database.EnsureCreated();

Console.WriteLine("Ensured that db exists!");