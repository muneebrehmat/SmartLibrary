using SmartLibrary.DTOs.Authorr;
using SmartLibrary.Repositories.Interfaces;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<AuthorResponseDto> creatAuthorAsync(CreateAuthorDto createAuthorDto)
        {
           var result = await _authorRepository.createAuthorAsync(createAuthorDto);
            return result;
        }
    }
}
