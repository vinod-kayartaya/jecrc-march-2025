using LibraryManagementSystem.Model;
using LibraryManagementSystem.Service;
using LibraryManagementSystem.CustomExceptions;
using Moq;
using System.Reflection;

namespace LibraryManagementSystemTests
{
    [TestFixture]
    public class Tests
    {
        private LibraryManager manager;
        private Mock<IList<Book>> mockBooks;
        private List<Book> booksList;

        [SetUp]
        public void Setup()
        {
            booksList = new List<Book>();
            mockBooks = new Mock<IList<Book>>();
            manager = new LibraryManager();
            manager.SetBooksList(mockBooks.Object);

            // Setup default behaviors
            mockBooks.Setup(m => m.Add(It.IsAny<Book>()))
                    .Callback<Book>(b => booksList.Add(b));
            mockBooks.Setup(m => m.Count)
                    .Returns(() => booksList.Count);
            mockBooks.Setup(m => m[It.IsAny<int>()])
                    .Returns<int>(i => booksList[i]);
            mockBooks.Setup(m => m.GetEnumerator())
                    .Returns(() => booksList.GetEnumerator());
        }

        [Test]
        public void AddBook_WithUniqueISBN_ShouldAddBook()
        {
            // Arrange
            Book book = new Book { ISBN = "ASD123", Title = "C# Unleashed", Author = "Vinod", PublicationYear = 2020, IsAvailable = true };

            // Act
            manager.AddBook(book);

            // Assert
            mockBooks.Verify(m => m.Add(book), Times.Once);
            Assert.That(booksList.Count, Is.EqualTo(1));
            Assert.That(booksList[0], Is.EqualTo(book));
        }

        [Test]
        public void AddBook_WithDuplicateISBN_ShouldThrowException()
        {
            // Arrange
            Book book1 = new Book { ISBN = "ASD123", Title = "C# Unleashed", Author = "Vinod", PublicationYear = 2020, IsAvailable = true };
            Book book2 = new Book { ISBN = "ASD123", Title = "Different Book", Author = "Someone", PublicationYear = 2021, IsAvailable = true };
            
            booksList.Add(book1); // Add first book to our tracking list

            // Act & Assert
            Assert.Throws<DuplicateBookException>(() => manager.AddBook(book2));
            mockBooks.Verify(m => m.Add(book2), Times.Never);
        }
    }
}