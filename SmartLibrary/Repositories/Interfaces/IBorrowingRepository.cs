using SmartLibrary.DTOs.Borrowings;
using SmartLibrary.Models;

namespace SmartLibrary.Repositories.Interfaces
{
    public interface IBorrowingRepository
    {
        Task<BorrowResponseDto> BorrowBookAsync(BorrowBookDto borrowBookDto);
        Task<List<BorrowResponseDto>> GetAllBorrowedAsync();
        Task<ReturnResponseDto> ReturnBookAsync(ReturnBookDto returnBookDto);
    }
}
