using ConsoleAppWithEntityFrameworkAndMySQL.Data;
using ConsoleAppWithEntityFrameworkAndMySQL.Service;

// Setup database context
var dbOptions = DatabaseConfig.GetDbContextOptions();
using var dbContext = new BookDbContext(dbOptions);

// Setup services
var bookService = new BookService(dbContext);

// Ensure database is created
bookService.EnsureDatabaseCreated();

// Seed initial data if needed
if (!bookService.HasAnyBooks())
{
    Console.WriteLine("Seeding initial data...");
    bookService.SeedInitialData();
    Console.WriteLine("Initial data seeded successfully!");
}

// Run the application
var uiService = new ConsoleUIService(bookService);
uiService.RunMenu();
