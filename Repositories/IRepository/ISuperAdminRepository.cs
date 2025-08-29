using Microsoft.AspNetCore.Identity;
using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.Models;

namespace Resturant_Labb1.Repositories.IRepository
{
    public interface ISuperAdminRepository
    {
        Task<SuperAdmin> AddAsync(SuperAdmin superAdmin);
        Task<SuperAdmin> GetByUsernameAsync(string Username);

    }
}
