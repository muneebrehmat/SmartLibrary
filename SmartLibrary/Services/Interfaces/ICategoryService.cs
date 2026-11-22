using SmartLibrary.DTOs.Category;

namespace SmartLibrary.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> CreateCategoryAync(CreateCategoryDto createCategoryDto);
    }
}
