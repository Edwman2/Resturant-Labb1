using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Models;

namespace Resturant_Labb1.Services.IServices
{
    public interface IResturantTableService
    {
        Task<List<TableDTO>> GetAllResturantTablesAsync();
        Task<TableDTO> GetResturantTablesByIdAsync(int id);
        Task<TableDTO> CreateResturantTableAsync(CreateTableDTO tableDTO);
        Task<bool> DeleteResturantTableAsync(int id);
        Task<bool> UpdateResturantTableAsync(int TableId, UpdateTableDTO createTableDTO);

    }
}
