using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLibrary.DTOs.Category;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            try
            {
                var result = await _categoryService.CreateCategoryAync(dto);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
