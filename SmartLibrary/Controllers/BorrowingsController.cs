using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLibrary.DTOs.Borrowings;
using SmartLibrary.Services.Implementation;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingsController : ControllerBase
    {
        private readonly IBorrowingService borrowingService;

        public BorrowingsController(IBorrowingService borrowingService)
        {
            this.borrowingService = borrowingService;
        }
        [Authorize]
        [HttpPost("BorrowBook")]
        public async Task<IActionResult> BorrowBook(BorrowBookDto dto)
        {
            try
            {
                var result = await borrowingService.BorrowBookAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get_All_Borrowed")]
        public async Task<IActionResult> GetAll()
        {
            var result = await borrowingService.getAllBorrowedAsync();
            return Ok(result);
        }
        [HttpPost("return")]
        public async Task<IActionResult> ReturnBook(ReturnBookDto returnBookDto)
        {
            var result = await borrowingService.ReturnBookAsync(returnBookDto);

            return Ok(result);
        }
    }
}
