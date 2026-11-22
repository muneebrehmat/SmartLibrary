using SmartLibrary.DTOs.Books;

namespace SmartLibrary.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<BookResponseDto> createBooksAsync(CreateBookDto createBookDto);
        Task<List<BookResponseDto>> GetAllBooksAsync();
        Task<string> UpdateBookAsync(int BookId, UpdateBookDto updateBookDto);
        Task<BookResponseDto> GetBookById(int BookId);
    }
}
