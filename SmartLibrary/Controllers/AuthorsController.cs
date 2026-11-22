using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLibrary.DTOs.Authorr;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService ) 
        {
            _authorService = authorService;
        }
        [HttpPost("CreateAuthor")]
        public async Task<IActionResult> Create(CreateAuthorDto dto)
        {
            try
            {
                var result = await _authorService.creatAuthorAsync(dto);
                return Ok("Author created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
