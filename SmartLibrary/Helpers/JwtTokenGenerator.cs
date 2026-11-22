using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SmartLibrary.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartLibrary.Helpers
{
    public class JwtTokenGenerator
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public JwtTokenGenerator(IConfiguration configuration,UserManager<ApplicationUser> userManager)
        {
            this.configuration = configuration;
            _userManager = userManager;
        }
        public async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Secretkey"]);

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("FullName", user.FullName),
            };
            foreach (var role in roles)
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiryMinutes"]!)),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new
                SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
