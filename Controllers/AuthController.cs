using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Resturant_Labb1.Data;
using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Models;
using Resturant_Labb1.Services;
using Resturant_Labb1.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;

namespace Resturant_Labb1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ResturantDbContext _context;
        private readonly IConfiguration _configuration;

        private readonly ISuperAdminService _adminService;

        public AuthController(ResturantDbContext context,IConfiguration configuration,ISuperAdminService adminService)
        {
            _context = context;
            _configuration = configuration;
            _adminService = adminService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterSuperAdminDTO adminDTO)
        {
            var existingUser = await _context.SuperAdmins.FirstOrDefaultAsync(s => s.Username == adminDTO.Username);
            if(existingUser != null)
            {
                return BadRequest("Username is already in use");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(adminDTO.PasswordHash);

            var newAccount = new SuperAdmin
            {
                Username = adminDTO.Username,
                Role = "SuperAdmin",
                PasswordHash = passwordHash
            };

            _context.SuperAdmins.Add(newAccount);
            _context.SaveChangesAsync();

            return Ok();


            
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _context.SuperAdmins.FirstOrDefaultAsync(u => u.Username == loginDTO.Username);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            bool passwordMatch = BCrypt.Net.BCrypt.Verify(loginDTO.PasswordHash, user.PasswordHash);
            if(!passwordMatch)
            {
                return Unauthorized("invalid username or password");
            }

            var token = GenerateJwtToken(user);

            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                SuperAdminId = user.SuperAdminId
            };

            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();




            return Ok(new 
            {
                accessToken = token,
                refreshToken = refreshToken.Token
            });
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutDTO logoutDTO)
        {
            var success = await _adminService.LogoutAsync(logoutDTO.Username, logoutDTO.RefreshToken);

            if(!success)
            {
                return Unauthorized(new { message = "logout failed" });

               
            }
            return Ok(new { message = "Logged out successfully" });
        }

        private string GenerateJwtToken(SuperAdmin admin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,$"{admin.Username}"),
                new Claim(ClaimTypes.Role, admin.Role)
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        

    }
}
