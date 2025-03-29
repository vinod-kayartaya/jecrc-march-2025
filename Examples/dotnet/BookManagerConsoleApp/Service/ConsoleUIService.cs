using ConsoleAppWithEntityFrameworkAndMySQL.Model;

namespace ConsoleAppWithEntityFrameworkAndMySQL.Service
{
    public class ConsoleUIService
    {
        private readonly BookService _bookService;

        public ConsoleUIService(BookService bookService)
        {
            _bookService = bookService;
        }

        public void RunMenu()
        {
            bool exit = false;
            while (!exit)
            {
                DisplayMenu();
                var choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        DisplayAllBooks();
                        break;
                    case "2":
                        AddNewBook();
                        break;
                    case "3":
                        UpdateBook();
                        break;
                    case "4":
                        DeleteBook();
                        break;
                    case "5":
                        SearchBooks();
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("=== Book Management System ===");
            Console.WriteLine("1. Display all books");
            Console.WriteLine("2. Add a new book");
            Console.WriteLine("3. Update a book");
            Console.WriteLine("4. Delete a book");
            Console.WriteLine("5. Search books");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1-6): ");
        }

        private void DisplayAllBooks()
        {
            var books = _bookService.GetAllBooks();
            
            if (books.Count == 0)
            {
                Console.WriteLine("No books found in the database.");
                return;
            }
            
            Console.WriteLine("\n=== All Books ===");
            DisplayBooks(books);
        }

        private void DisplayBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Price: {book.Price:C}");
                Console.WriteLine(new string('-', 30));
            }
        }

        private void AddNewBook()
        {
            Console.WriteLine("\n=== Add New Book ===");
            
            Console.Write("Enter book title: ");
            var title = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Enter author name: ");
            var author = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Enter price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price format. Book not added.");
                return;
            }
            
            var newBook = new Book
            {
                Id = Guid.NewGuid(),
                Title = title,
                Author = author,
                Price = price
            };
            
            _bookService.AddBook(newBook);
            Console.WriteLine("Book added successfully!");
        }

        private void UpdateBook()
        {
            Console.WriteLine("\n=== Update Book ===");
            
            DisplayAllBooks();
            
            Console.Write("Enter the ID of the book to update: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid bookId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }
            
            var bookToUpdate = _bookService.GetBookById(bookId);
            
            if (bookToUpdate == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            
            Console.WriteLine($"Updating book: {bookToUpdate.Title} by {bookToUpdate.Author}");
            
            Console.Write("Enter new title (leave empty to keep current): ");
            var title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                bookToUpdate.Title = title;
            }
            
            Console.Write("Enter new author (leave empty to keep current): ");
            var author = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(author))
            {
                bookToUpdate.Author = author;
            }
            
            Console.Write("Enter new price (leave empty to keep current): ");
            var priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal price))
            {
                bookToUpdate.Price = price;
            }
            
            _bookService.UpdateBook(bookToUpdate);
            Console.WriteLine("Book updated successfully!");
        }

        private void DeleteBook()
        {
            Console.WriteLine("\n=== Delete Book ===");
            
            DisplayAllBooks();
            
            Console.Write("Enter the ID of the book to delete: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid bookId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }
            
            var bookToDelete = _bookService.GetBookById(bookId);
            
            if (bookToDelete == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            
            Console.WriteLine($"Are you sure you want to delete '{bookToDelete.Title}' by {bookToDelete.Author}? (y/n)");
            var confirmation = Console.ReadLine()?.ToLower();
            
            if (confirmation == "y" || confirmation == "yes")
            {
                _bookService.DeleteBook(bookToDelete);
                Console.WriteLine("Book deleted successfully!");
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
        }

        private void SearchBooks()
        {
            Console.WriteLine("\n=== Search Books ===");
            Console.WriteLine("1. Search by title");
            Console.WriteLine("2. Search by author");
            Console.Write("Enter your choice (1-2): ");
            
            var choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    Console.Write("Enter title to search: ");
                    var title = Console.ReadLine() ?? string.Empty;
                    var booksByTitle = _bookService.SearchBooksByTitle(title);
                    DisplaySearchResults(booksByTitle);
                    break;
                case "2":
                    Console.Write("Enter author to search: ");
                    var author = Console.ReadLine() ?? string.Empty;
                    var booksByAuthor = _bookService.SearchBooksByAuthor(author);
                    DisplaySearchResults(booksByAuthor);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void DisplaySearchResults(List<Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No matching books found.");
                return;
            }
            
            Console.WriteLine($"\nFound {books.Count} matching books:");
            DisplayBooks(books);
        }
    }
} 