using Resturant_Labb1.Models;

namespace Resturant_Labb1.Repositories.IRepository
{
    public interface IMenuRepository
    {
        Task<List<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemByIdAsync(int id);
        Task<MenuItem> AddMenuItemAsync(MenuItem item);
        Task<bool> DeleteMenuItemAsync(int id);
        Task SaveChangesAsync();
    }
}
