using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resturant_Labb1.Data;
using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Models;
using Resturant_Labb1.Repositories.IRepository;
using Resturant_Labb1.Services.IServices;

namespace Resturant_Labb1.Services
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly ISuperAdminRepository _superAdminRepo;
        private readonly IPasswordHasher<SuperAdmin> _passwordHasher;
        private readonly ResturantDbContext _context;

        public SuperAdminService(ISuperAdminRepository adminRepo, IPasswordHasher<SuperAdmin> passwordHasher, ResturantDbContext context)
        {
            _superAdminRepo = adminRepo;
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public async Task<bool> LoginAsync(LoginDTO loginDTO)
        {
            var admin = await _superAdminRepo.GetByUsernameAsync(loginDTO.Username);
            if(admin == null)
            {
                return false;
            }
            return _passwordHasher.VerifyHashedPassword(admin, admin.PasswordHash, loginDTO.PasswordHash)
                == PasswordVerificationResult.Success;
        }

        public async Task<SuperAdminDTO> RegisterAsync(RegisterSuperAdminDTO registerSuperAdminDTO)
        {
            var superAdmin = new SuperAdmin
            {
                Username = registerSuperAdminDTO.Username,
                Role = registerSuperAdminDTO.Role
            };

            superAdmin.PasswordHash = _passwordHasher.HashPassword(superAdmin, registerSuperAdminDTO.PasswordHash);

            var createdAdmin = await _superAdminRepo.AddAsync(superAdmin);

            return new SuperAdminDTO
            {
                SuperAdminId = superAdmin.SuperAdminId,
                Username = superAdmin.Username,
                Role = superAdmin.Role
            };


        }
        public async Task<bool> LogoutAsync(string username, string refreshToken)
        {
            var user = await _context.SuperAdmins
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return false;
            }

            var token = await _context.RefreshTokens
                .FirstOrDefaultAsync(t => t.Token == refreshToken && t.SuperAdminId == user.SuperAdminId);

            if (token == null)
            {
                return false;
            }

            token.IsRevoked = true;
            token.RevokedAt = DateTime.UtcNow;

            _context.RefreshTokens.Update(token);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
