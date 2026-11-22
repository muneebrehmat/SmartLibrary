using Microsoft.AspNetCore.Identity;

namespace SmartLibrary.Services.Interfaces
{
    public interface IPasswordResetService
    {
        Task<string?> GenerateResetTokenAsync(string email);

        Task<IdentityResult> ResetPasswordAsync(
            string email,
            string token,
            string newPassword);
    }
}
