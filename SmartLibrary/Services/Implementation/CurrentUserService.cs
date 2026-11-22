using SmartLibrary.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SmartLibrary.Services.Implementation
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId =>
     _httpContextAccessor.HttpContext?
         .User.FindFirstValue(ClaimTypes.NameIdentifier)
     ?? throw new UnauthorizedAccessException("User ID not found.");

        public string FullName =>
        _httpContextAccessor.HttpContext?
            .User
            .FindFirstValue("FullName")
        ?? throw new UnauthorizedAccessException("Member name not found.");


    }
}
