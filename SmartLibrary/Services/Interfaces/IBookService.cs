using SmartLibrary.DTOs.Books;

namespace SmartLibrary.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookResponseDto> createBookAsync(CreateBookDto createBookDto);
        Task<List<BookResponseDto>> GetAllBooksAsync();
        Task<string> UpdateBookAsync(int BookId, UpdateBookDto updateBookDto);
        Task<BookResponseDto> GetBookById(int BookId);

    }
}
