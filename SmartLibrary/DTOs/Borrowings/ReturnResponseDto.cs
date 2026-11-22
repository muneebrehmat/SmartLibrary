namespace SmartLibrary.DTOs.Borrowings
{
    public class ReturnResponseDto
    {
        public string BookTitle { get; set; }
        public string MemberName { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Message { get; set; }
    }
}
