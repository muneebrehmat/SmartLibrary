using SmartLibrary.DTOs.Auth;
using SmartLibrary.Models;

namespace SmartLibrary.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthResponseDto> RegisterUserAsync(RegisterDto registerDto);
        Task<string> LoginUserAsync(LoginDto loginDto);
        Task<ApplicationUser?> GetByEmailAsync(string email);
    }
}
