namespace ConsoleAppWithEntityFrameworkAndMySQL.Model
{
    public class Book
    {
        public Guid Id { set; get; }
        public required string Title { set; get; }
        public required string Author { set; get; }
        public decimal Price { set; get; }
    }
}
