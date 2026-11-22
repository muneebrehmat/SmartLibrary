using SmartLibrary.DTOs.Auth;
using SmartLibrary.Repositories.Interfaces;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<AuthResponseDto> CreateUserAsync(RegisterDto registerDto)
        {
            var result = await _authRepository.RegisterUserAsync(registerDto);
            return result;
        }

        public async Task<string> LoginUserAsync(LoginDto loginDto)
        {
            var result = await _authRepository.LoginUserAsync(loginDto);
            return result;
        }
    }
}
