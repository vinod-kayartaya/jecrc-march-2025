using ConsoleAppWithEntityFrameworkAndMySQL.Data;
using ConsoleAppWithEntityFrameworkAndMySQL.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppWithEntityFrameworkAndMySQL.Service
{
    public class BookService
    {
        private readonly BookDbContext _context;

        public BookService(BookDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book? GetBookById(Guid id)
        {
            return _context.Books.Find(id);
        }

        public List<Book> SearchBooksByTitle(string title)
        {
            return _context.Books.Where(b => b.Title.Contains(title)).ToList();
        }

        public List<Book> SearchBooksByAuthor(string author)
        {
            return _context.Books.Where(b => b.Author.Contains(author)).ToList();
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            // If the entity is not being tracked, attach it
            if (!_context.Books.Local.Any(b => b.Id == book.Id))
            {
                _context.Books.Update(book);
            }
            // Otherwise, EF Core is already tracking it and will detect changes
            
            _context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public bool DatabaseExists()
        {
            return _context.Database.CanConnect();
        }

        public void EnsureDatabaseCreated()
        {
            _context.Database.EnsureCreated();
        }

        public bool HasAnyBooks()
        {
            return _context.Books.Any();
        }

        public void SeedInitialData()
        {
            var books = new List<Book>
            {
                new Book { Id = Guid.NewGuid(), Title = "Let us C#", Author = "Vinod", Price = 3999.0m },
                new Book { Id = Guid.NewGuid(), Title = "Let us Python", Author = "Vinod", Price = 3599.0m },
                new Book { Id = Guid.NewGuid(), Title = "Clean Code", Author = "Robert C. Martin", Price = 4599.0m },
                new Book { Id = Guid.NewGuid(), Title = "Design Patterns", Author = "Erich Gamma", Price = 5299.0m }
            };
            
            _context.Books.AddRange(books);
            _context.SaveChanges();
        }
    }
} 