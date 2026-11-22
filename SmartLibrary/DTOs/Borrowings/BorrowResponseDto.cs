namespace SmartLibrary.DTOs.Borrowings
{
    public class BorrowResponseDto
    {
        public string BookTitle {  get; set; }
        public string MemberName {  get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
