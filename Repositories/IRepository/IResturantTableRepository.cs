using Resturant_Labb1.Models;

namespace Resturant_Labb1.Repositories.IRepository
{
    public interface IResturantTableRepository
    {
        Task<List<Table>> GetAllResturantTablesAsync();
        Task<Table> GetResturantTablesById(int TableId);
        Task<Table> AddResturantTableAsync(Table resturantTable);
        Task<bool> DeleteResturantTableAsync(int TableId);
        Task SaveChangesAsync();

    }
}
