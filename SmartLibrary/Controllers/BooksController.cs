using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLibrary.DTOs.Books;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost("CreateBook")]
        public async Task<IActionResult> Create(CreateBookDto dto)
        {
            try
            {
                var result = await _bookService.createBookAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> getAll()
        {
            var Books = await _bookService.GetAllBooksAsync();
            return Ok(Books);
        }
        [HttpPut("Update_Book")]
        public async Task<IActionResult> Update(int  id, UpdateBookDto dto)
        {
            try
            {
                var result = await _bookService.UpdateBookAsync(id, dto);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get_Book_By_Id")]
        public async Task<IActionResult> GetBook(int id)
        {
            try
            {
                var result = await _bookService.GetBookById(id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
