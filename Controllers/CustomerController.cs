using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_Labb1.DTOs.Customers;
using Resturant_Labb1.Services.IServices;

namespace Resturant_Labb1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]

        public async Task<ActionResult<List<CustomerDTO>>> GetAllCustomersAsync()
        {
            var customers =  await _customerService.GetAllCustomersAsync();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
        {
            var customers = await _customerService.GetCustomersByIdAsync(id);
            if(customers == null)
            {
                return NotFound();
            }

            return Ok(customers);

        }
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomerAsync(CustomerDTO customer)
        {
            var createdCustomer = await _customerService.CreateCustomerAsync(customer);

            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerId }, createdCustomer);
        }
    }
}
