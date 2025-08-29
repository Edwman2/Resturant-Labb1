using Microsoft.AspNetCore.Identity;
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

        public SuperAdminService(ISuperAdminRepository adminRepo, IPasswordHasher<SuperAdmin> passwordHasher)
        {
            _superAdminRepo = adminRepo;
            _passwordHasher = passwordHasher;
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
                Id = superAdmin.Id,
                Username = superAdmin.Username,
                Role = superAdmin.Role
            };


        }
    }
}
