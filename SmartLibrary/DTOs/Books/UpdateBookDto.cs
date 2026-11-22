namespace SmartLibrary.DTOs.Books
{
    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
    }
}
