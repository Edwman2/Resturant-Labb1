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
        public async Task<Table> AddResturantTableAsync(Table tables)
        {
            _context.Tables.Add(tables);
            await _context.SaveChangesAsync();

            return tables;
        }

        public async Task<bool> DeleteResturantTableAsync(int id)
        {
            var rowsAffected = await _context.Tables.Where(r => r.TableId == id).ExecuteDeleteAsync();

            if(rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public Task<List<Table>> GetAllResturantTablesAsync()
        {
            var tables = _context.Tables.ToListAsync();

            return tables;
        }

        public async Task<Table> GetResturantTablesById(int TableId)
        {
            return await _context.Tables.FindAsync(TableId);

           
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
