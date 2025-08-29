using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Models;

namespace Resturant_Labb1.Services.IServices
{
    public interface IResturantTableService
    {
        Task<List<TableDTO>> GetAllResturantTablesAsync();
        Task<TableDTO> GetResturantTablesByIdAsync(int TableId);
        Task<TableDTO> CreateResturantTableAsync(TableDTO tableDTO);
        Task<bool> DeleteResturantTableAsync(int TableId);
        Task<bool> UpdateResturantTableAsync(int TableId, UpdateTableDTO createTableDTO);

    }
}
