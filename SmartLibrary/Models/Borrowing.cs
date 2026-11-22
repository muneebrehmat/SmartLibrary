namespace SmartLibrary.Models
{
    public class Borrowing
    {
        public int Id { get; set; }

        // Book
        public int BookId { get; set; }

        public Book Book { get; set; } = null!;

        // Identity User
        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        // Dates
        public DateTime BorrowDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
