using Microsoft.AspNetCore.Http.HttpResults;
using Resturant_Labb1.DTOs.Customers;
using Resturant_Labb1.Models;
using Resturant_Labb1.Repositories.IRepository;
using Resturant_Labb1.Services.IServices;

namespace Resturant_Labb1.Services
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<ResponseCustomerDTO> CreateCustomerAsync(ResponseCustomerDTO responseCustomerDTO)
        {
            var customers = new Customer
            { 
                Name = responseCustomerDTO.Name,
                Lastname = responseCustomerDTO.Lastname,
                Phonenumber = responseCustomerDTO.Phonenumber,
                Email = responseCustomerDTO.Email
            };

            var newCustomer = await _customerRepo.AddCustomerAsync(customers);

            return new ResponseCustomerDTO
            {
                Name = customers.Name,
                Lastname = customers.Lastname,
                Phonenumber = customers.Phonenumber,
                Email = customers.Email
            };
        }

        public async Task<bool> DeleteCustomerAsync(int CustomerId)
        {
            return await _customerRepo.DeleteCustomerAsync(CustomerId);
        }

        public async Task<List<ResponseCustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepo.GetAllCustomersAsync();
            var customerDTO = customers.Select(c => new ResponseCustomerDTO
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                Lastname = c.Lastname,
                Phonenumber = c.Phonenumber,
                Email = c.Email

            }).ToList();

            return customerDTO;
        }

        public async Task<ResponseCustomerDTO> GetCustomersByIdAsync(int CustomerId)
        {
            var customer = await _customerRepo.GetCustomerById(CustomerId);

            if(customer == null)
            {
                return null;
            }

            var customerDTO = new ResponseCustomerDTO
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Lastname = customer.Lastname,
                Phonenumber = customer.Phonenumber,
                Email = customer.Email
            };

            return customerDTO;
        }

        public async Task<bool> UpdateCustomerAsync(int id, PostCustomerDTO customerDTO)
        {
            var customer = await _customerRepo.GetCustomerById(id);
            if(customer == null)
            {
                return false;
            }
            customer.Name = customerDTO.Name;
            customer.Lastname = customerDTO.Lastname;
            customer.Phonenumber = customerDTO.Phonenumber;
            customer.Email = customerDTO.Email;

            await _customerRepo.SaveChangesAsync();

            return true; 
        }
    }
}
