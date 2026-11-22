using SmartLibrary.DTOs.Authorr;

namespace SmartLibrary.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<AuthorResponseDto> createAuthorAsync(CreateAuthorDto createAuthorDto);
    }
}
