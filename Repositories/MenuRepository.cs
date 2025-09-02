using Microsoft.EntityFrameworkCore;
using Resturant_Labb1.Data;
using Resturant_Labb1.Models;
using Resturant_Labb1.Repositories.IRepository;
using System.Runtime.CompilerServices;

namespace Resturant_Labb1.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ResturantDbContext _context;

        public MenuRepository(ResturantDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItem>> GetAllMenuItemsAsync()
        {
            var item = await _context.MenuItems.ToListAsync();

            return item; 
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int id)
        {
            return await _context.MenuItems.FindAsync(id);

            
        }

        public async Task<MenuItem> AddMenuItemsAsync(MenuItem item)
        {
            _context.MenuItems.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            var rowsAffected = await _context.MenuItems.Where(i => i.ItemId == id).ExecuteDeleteAsync();

            if(rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
