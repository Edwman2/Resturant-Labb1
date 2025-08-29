using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;

namespace Resturant_Labb1.Services.IServices
{
    public interface ISuperAdminService
    {
        Task<SuperAdminDTO> RegisterAsync(RegisterSuperAdminDTO registerSuperAdminDTO);
        Task<bool> LoginAsync(LoginDTO loginDTO);
    }
}
