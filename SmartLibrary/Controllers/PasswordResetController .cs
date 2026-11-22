using AspIdentityProject.DTOS.PasswordResetDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetController : ControllerBase
    {
        private readonly IPasswordResetService _passwordResetService;

        public PasswordResetController(
            IPasswordResetService passwordResetService)
        {
            _passwordResetService = passwordResetService;
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(
            [FromBody] ForgotPasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest(new
                {
                    message = "Email is required."
                });
            }

            var token = await _passwordResetService
                .GenerateResetTokenAsync(request.Email);

            if (token == null)
            {
                return NotFound(new
                {
                    message = "This Email Does not Exist."
                });
            }

            return Ok(new
            {
                
                token = token
            });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(
            [FromBody] ResetPasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest(new
                {
                    message = "Email is required."
                });
            }

            if (string.IsNullOrWhiteSpace(request.Token))
            {
                return BadRequest(new
                {
                    message = "Reset token is required."
                });
            }

            if (string.IsNullOrWhiteSpace(request.NewPassword))
            {
                return BadRequest(new
                {
                    message = "New password is required."
                });
            }

            var result = await _passwordResetService
                .ResetPasswordAsync(
                    request.Email,
                    request.Token,
                    request.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Password reset failed.",
                    errors = result.Errors.Select(x => new
                    {
                        x.Code,
                        x.Description
                    })
                });
            }

            return Ok(new
            {
                message = "Password reset successfully."
            });
        }
    }
}
