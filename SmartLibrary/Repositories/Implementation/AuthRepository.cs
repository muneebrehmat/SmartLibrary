using Microsoft.AspNetCore.Identity;
using SmartLibrary.Data;
using SmartLibrary.DTOs.Auth;
using SmartLibrary.Helpers;
using SmartLibrary.Models;
using SmartLibrary.Repositories.Interfaces;

namespace SmartLibrary.Repositories.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly JwtTokenGenerator _tokenService;

        public AuthRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            ApplicationDbContext dbContext,JwtTokenGenerator tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<string> LoginUserAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if(user == null)
            {
                throw new Exception("Invalid Username or password");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
            if (!result.Succeeded)
            {
                throw new Exception("Invalid Username or password");

            }
            var token = await _tokenService.GenerateTokenAsync(user);
            return token;
        }

        public async Task<AuthResponseDto> RegisterUserAsync(RegisterDto registerDto)
        {
            var existingUsername = await _userManager.FindByNameAsync(registerDto.Username);

            if (existingUsername != null)
            {
                return new AuthResponseDto
                {
                    Message = $"{registerDto.Username} this username is already taken!",
                    success = false
                };
            }

            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Username,
                FullName = registerDto.Username

            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return new AuthResponseDto
                {
                    Message = result.Errors.First().Description,
                    success = false

                };
            }
            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded)
            {
                // Remove the user if role assignment fails
                await _userManager.DeleteAsync(user);

                return new AuthResponseDto
                {
                    Message = roleResult.Errors.First().Description,
                    success = false
                };
            }

            return new AuthResponseDto
            {
                Message = "User created successfully.",
                success = true

            };
        }
    }
}
