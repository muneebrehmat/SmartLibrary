using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLibrary.DTOs.Auth;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.CreateUserAsync(dto);
            if (result.success)
            {
                return Ok(new
                {
                    message = result.Message
                });
            }
            return BadRequest(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                var result = await _authService.LoginUserAsync(dto);
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
