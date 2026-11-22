namespace SmartLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }
        public string Status { get; set; }
        // Author
        public int AuthorId { get; set; }

        public Author Author { get; set; } = null!;

        // Category
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        // Borrowings
        public ICollection<Borrowing> Borrowings { get; set; }
            = new List<Borrowing>();
    }
}
