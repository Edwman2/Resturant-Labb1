using Resturant_Labb1.DTOs.Customers;

namespace Resturant_Labb1.Services.IServices
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetAllCustomersByIdAsync(int CustomerId);
        Task<int> CreateCustomerAsync(CustomerDTO customerDTO);
        Task<bool> UpdateCustomerAsync(int id, CustomerDTO customerDTO);
        Task<bool> DeleteCustomerAsync(int CustomerId);
    }
}
