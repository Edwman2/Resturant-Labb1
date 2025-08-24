using Resturant_Labb1.DTOs.Customers;

namespace Resturant_Labb1.Services.IServices
{
    public interface ICustomerService
    {
        Task<List<ResponseCustomerDTO>> GetAllCustomersAsync();
        Task<ResponseCustomerDTO> GetCustomersByIdAsync(int CustomerId);
        Task<ResponseCustomerDTO> CreateCustomerAsync(ResponseCustomerDTO responseSCustomerDTO);
        Task<bool> UpdateCustomerAsync(int id, PostCustomerDTO postCustomerDTO);
        Task<bool> DeleteCustomerAsync(int CustomerId);
    }
}
