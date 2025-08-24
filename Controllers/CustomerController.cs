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

        public async Task<ActionResult<List<PostCustomerDTO>>> GetAllCustomersAsync()
        {
            var customers =  await _customerService.GetAllCustomersAsync();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostCustomerDTO>> GetCustomerById(int id)
        {
            var customers = await _customerService.GetCustomersByIdAsync(id);
            if(customers == null)
            {
                return NotFound();
            }

            return Ok(customers);

        }
        [HttpPost]
        public async Task<ActionResult<PostCustomerDTO>> CreateCustomerAsync(PostCustomerDTO customer)
        {
            var createdCustomer = await _customerService.CreateCustomerAsync(customer);

            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerId }, createdCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PostCustomerDTO>> DeleteCustomerAsync(int id)
        {
            var success = await _customerService.DeleteCustomerAsync(id);

            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PostCustomerDTO>> UpdateCustomerAsync(int id, [FromBody] PostCustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest("User data is required");
            }

            var customerUpdate = await _customerService.UpdateCustomerAsync(id, customerDTO);

            if(!customerUpdate)
            {
                return NotFound($"Customer with id {id} not found");
            }

            return NoContent();
        }
        
        
    }
}
