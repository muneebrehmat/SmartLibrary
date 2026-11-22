using SmartLibrary.Data;
using SmartLibrary.DTOs.Category;
using SmartLibrary.Models;
using SmartLibrary.Repositories.Interfaces;

namespace SmartLibrary.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CategoryResponseDto> CreateCategoryAsync(CreateCategoryDto createCategory)
        {
            var category = new Category
            {
                Name = createCategory.Name,
                Description = createCategory.Description
            };
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = createCategory.Description
            };

        }
    }
}
