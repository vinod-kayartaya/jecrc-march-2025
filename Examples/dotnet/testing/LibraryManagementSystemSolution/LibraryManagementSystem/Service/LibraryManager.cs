using LibraryManagementSystem.CustomExceptions;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Service
{
    public class LibraryManager
    {
        private IList<Book>? books;

        public LibraryManager()
        {
            this.books = new List<Book>();
        }

        // Method to set books list for testing
        public void SetBooksList(IList<Book> booksList)
        {
            this.books = booksList;
        }

        public void AddBook(Book book)
        {
            
            if (books.Any(b => b.ISBN == book.ISBN))
            {
                throw new DuplicateBookException();
            }

            if(book.Title==null || book.Title == "")
            {
                throw new InvalidBookException();
            }

            if(book.PublicationYear < 1900 || book.PublicationYear > 2025)
            {
                throw new InvalidBookException();
            }

            books.Add(book);
        }
    }
}
