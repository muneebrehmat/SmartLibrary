using SmartLibrary.DTOs.Auth;

namespace SmartLibrary.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> CreateUserAsync(RegisterDto registerDto);
        Task<string> LoginUserAsync(LoginDto loginDto);
    }
}
