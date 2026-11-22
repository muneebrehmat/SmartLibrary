using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using SmartLibrary.Models;
using SmartLibrary.Repositories.Interfaces;
using SmartLibrary.Services.Interfaces;
using System.Text;

namespace SmartLibrary.Services.Implementation
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IAuthRepository _authRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public PasswordResetService(
            IAuthRepository authRepository,
            UserManager<ApplicationUser> userManager)
        {
            _authRepository = authRepository;
            _userManager = userManager;
        }

        public async Task<string?> GenerateResetTokenAsync(string email)
        {
            var user = await _authRepository.GetByEmailAsync(email);

            if (user == null)
            {
                return null;
            }

            var token = await _userManager
                .GeneratePasswordResetTokenAsync(user);

            var encodedToken = WebEncoders.Base64UrlEncode(
                Encoding.UTF8.GetBytes(token));

            return encodedToken;
        }

        public async Task<IdentityResult> ResetPasswordAsync(
            string email,
            string token,
            string newPassword)
        {
            var user = await _authRepository.GetByEmailAsync(email);

            if (user == null)
            {
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = "UserNotFound",
                        Description = "User not found."
                    });
            }

            string decodedToken;

            try
            {
                decodedToken = Encoding.UTF8.GetString(
                    WebEncoders.Base64UrlDecode(token));
            }
            catch
            {
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = "InvalidToken",
                        Description = "Invalid reset token."
                    });
            }

            var result = await _userManager.ResetPasswordAsync(
                user,
                decodedToken,
                newPassword);

            return result;
        }
    }
}
