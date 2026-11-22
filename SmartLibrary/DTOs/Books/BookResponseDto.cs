namespace SmartLibrary.DTOs.Books
{
    public class BookResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;
        public string Category { get; set; }
        public string Author { get; set; }
        public string Status {  get; set; }

    }
}
