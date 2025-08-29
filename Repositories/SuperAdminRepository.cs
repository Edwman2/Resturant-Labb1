using Microsoft.EntityFrameworkCore;
using Resturant_Labb1.Data;
using Resturant_Labb1.Models;
using Resturant_Labb1.Repositories.IRepository;

namespace Resturant_Labb1.Repositories
{
    public class SuperAdminRepository : ISuperAdminRepository
    {
        private readonly ResturantDbContext _resturantDb;

        public SuperAdminRepository(ResturantDbContext resturantDb)
        {
            _resturantDb = resturantDb;
        }

        public async Task<SuperAdmin> AddAsync(SuperAdmin superAdmin)
        {
            _resturantDb.SuperAdmins.Add(superAdmin);
            await _resturantDb.SaveChangesAsync();
            return superAdmin;
        }

        public async Task<SuperAdmin> GetByUsernameAsync(string Username)
        {
            return await _resturantDb.SuperAdmins.FirstOrDefaultAsync(s => s.Username == Username);
        }
    }
}
