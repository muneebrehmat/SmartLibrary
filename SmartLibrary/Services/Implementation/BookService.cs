using SmartLibrary.DTOs.Books;
using SmartLibrary.Repositories.Interfaces;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }
        public async Task<BookResponseDto> createBookAsync(CreateBookDto createBookDto)
        {
            var result = await _bookRepository.createBooksAsync(createBookDto);
            return result;
        }

        public async Task<List<BookResponseDto>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<BookResponseDto> GetBookById(int BookId)
        {
            var result = await _bookRepository.GetBookById(BookId);
            return result;
        }

        public async Task<string> UpdateBookAsync(int BookId, UpdateBookDto updateBookDto)
        {
            return await _bookRepository.UpdateBookAsync(BookId, updateBookDto);
        }
    }
}
