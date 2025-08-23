using Resturant_Labb1.Models;

namespace Resturant_Labb1.Repositories.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<int> AddCustomerAsync(Customer customer);
        Task<Customer> GetCustomerById(int CustomerId);
        Task<bool> DeleteCustomerAsync(int CustomerId);
        Task SaveChangesAsync();


    }
}
