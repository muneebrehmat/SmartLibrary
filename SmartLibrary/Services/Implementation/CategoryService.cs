using SmartLibrary.DTOs.Category;
using SmartLibrary.Repositories.Interfaces;
using SmartLibrary.Services.Interfaces;
namespace SmartLibrary.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryResponseDto> CreateCategoryAync(CreateCategoryDto createCategoryDto)
        {
            return await _categoryRepository.CreateCategoryAsync(createCategoryDto);
        }
    }
}
