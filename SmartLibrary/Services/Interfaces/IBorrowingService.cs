using SmartLibrary.DTOs.Borrowings;

namespace SmartLibrary.Services.Interfaces
{
    public interface IBorrowingService
    {
        Task<BorrowResponseDto> BorrowBookAsync(BorrowBookDto borrowBookDto);
        Task<List<BorrowResponseDto>> getAllBorrowedAsync();
        Task<ReturnResponseDto> ReturnBookAsync(ReturnBookDto returnBookDto);
    }
}
