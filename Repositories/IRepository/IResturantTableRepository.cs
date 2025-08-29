using Resturant_Labb1.Models;

namespace Resturant_Labb1.Repositories.IRepository
{
    public interface IResturantTableRepository
    {
        Task<List<ResturantTable>> GetAllResturantTablesAsync();
        Task<ResturantTable> GetResturantTablesById(int TableId);
        Task<ResturantTable> AddResturantTableAsync(ResturantTable resturantTable);
        Task<bool> DeleteResturantTableAsync(int TableId);
        Task SaveChangesAsync();

    }
}
