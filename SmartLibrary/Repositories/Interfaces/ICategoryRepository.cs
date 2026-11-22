using SmartLibrary.DTOs.Authorr;
using SmartLibrary.DTOs.Category;

namespace SmartLibrary.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<CategoryResponseDto> CreateCategoryAsync(CreateCategoryDto createCategory);

    }
}
