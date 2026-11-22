using SmartLibrary.DTOs.Authorr;

namespace SmartLibrary.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorResponseDto> creatAuthorAsync(CreateAuthorDto createAuthorDto);
    }
}
