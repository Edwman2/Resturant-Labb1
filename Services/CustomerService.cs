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

        public async Task<CustomerDTO> CreateCustomerAsync(CustomerDTO customerDTO)
        {
            var customers = new Customer
            { 
                Name = customerDTO.Name,
                Lastname = customerDTO.Lastname,
                Phonenumber = customerDTO.Phonenumber,
                Email = customerDTO.Email
            };

            var newCustomer = await _customerRepo.AddCustomerAsync(customers);

            return new CustomerDTO
            {
                CustomerId = newCustomer,
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

        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepo.GetAllCustomersAsync();
            var customerDTO = customers.Select(c => new CustomerDTO
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                Lastname = c.Lastname,
                Phonenumber = c.Phonenumber,
                Email = c.Email

            }).ToList();

            return customerDTO;
        }

        public async Task<CustomerDTO> GetCustomersByIdAsync(int CustomerId)
        {
            var customer = await _customerRepo.GetCustomerById(CustomerId);

            if(customer == null)
            {
                return null;
            }

            var customerDTO = new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Lastname = customer.Lastname,
                Phonenumber = customer.Phonenumber,
                Email = customer.Email
            };

            return customerDTO;
        }

        public async Task<bool> UpdateCustomerAsync(int id, CustomerDTO customerDTO)
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
