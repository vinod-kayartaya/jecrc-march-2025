using Microsoft.EntityFrameworkCore;
using ProductServiceWithEF.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    // Enable detailed EF Core logging
    options.EnableSensitiveDataLogging()
           .EnableDetailedErrors()
           .LogTo(Console.WriteLine);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Create the database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ProductDbContext>();
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        Console.WriteLine($"Using connection string: {connectionString}");
        
        Console.WriteLine("Attempting to create database...");
        var created = context.Database.EnsureCreated();
        Console.WriteLine($"Database creation result: {(created ? "Database was created" : "Database already exists")}");
        
        // Verify we can connect and the Products table exists
        var tableExists = context.Products.Any();
        Console.WriteLine($"Successfully connected to database. Products table exists and is accessible.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while setting up the database: {ex.Message}");
        Console.WriteLine($"Stack trace: {ex.StackTrace}");
    }
}

app.Run();
