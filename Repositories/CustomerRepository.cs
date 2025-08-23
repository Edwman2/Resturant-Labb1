using Microsoft.EntityFrameworkCore;
using Resturant_Labb1.Data;
using Resturant_Labb1.Models;
using Resturant_Labb1.Repositories.IRepository;

namespace Resturant_Labb1.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ResturantDbContext _context;

        public CustomerRepository(ResturantDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCustomerAsync(Customer customer)
        {
            _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer.CustomerId;
        }

        public async Task<bool> DeleteCustomerAsync(int Id)
        {
            var rowsAffected = await _context.Customers.Where(c => c.CustomerId == Id).ExecuteDeleteAsync();

            if (rowsAffected > 0 )
            {
                return true;
            }
            return false;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();

            return customers;
        }

        public async Task<Customer> GetCustomerById(int CustomerId)
        {
            return await _context.Customers.FindAsync(CustomerId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
