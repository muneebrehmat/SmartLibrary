using SmartLibrary.DTOs.Borrowings;
using SmartLibrary.Repositories.Interfaces;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Services.Implementation
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IBorrowingRepository _borrowingRepository;

        public BorrowingService(IBorrowingRepository borrowingRepository) 
        {
            _borrowingRepository = borrowingRepository;
        }
        public async Task<BorrowResponseDto> BorrowBookAsync(BorrowBookDto borrowBookDto)
        {
           var result = await _borrowingRepository.BorrowBookAsync(borrowBookDto);
            return result;
        }

        public async Task<List<BorrowResponseDto>> getAllBorrowedAsync()
        {
           return await _borrowingRepository.GetAllBorrowedAsync();
        }
        public async Task<ReturnResponseDto> ReturnBookAsync(ReturnBookDto returnBookDto)
        {
            return await _borrowingRepository.ReturnBookAsync(returnBookDto);
        }
    }
}
