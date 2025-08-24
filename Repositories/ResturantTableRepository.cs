using Microsoft.EntityFrameworkCore;
using Resturant_Labb1.Data;
using Resturant_Labb1.Models;
using Resturant_Labb1.Repositories.IRepository;

namespace Resturant_Labb1.Repositories
{
    public class ResturantTableRepository : IResturantTableRepository
    {
        private readonly ResturantDbContext _context;

        public ResturantTableRepository(ResturantDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddResturantTableAsync(ResturantTable resturantTable)
        {
            _context.ResturantTables.AddAsync(resturantTable);
            await _context.SaveChangesAsync();

            return resturantTable.TableId;
        }

        public async Task<bool> DeleteResturantTableAsync(int id)
        {
            var rowsAffected = await _context.ResturantTables.Where(r => r.TableId == id).ExecuteDeleteAsync();

            if(rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public Task<List<ResturantTable>> GetAllResturantTablesAsync()
        {
            var tables = _context.ResturantTables.ToListAsync();

            return tables;
        }

        public async Task<ResturantTable> GetResturantTablesById(int TableId)
        {
            return await _context.ResturantTables.FindAsync(TableId);

           
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
