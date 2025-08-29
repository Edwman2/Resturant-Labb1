using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Repositories.IRepository;
using Resturant_Labb1.Services.IServices;
using System.Runtime.InteropServices;

namespace Resturant_Labb1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingDTO>>> GetAllBookingsAsync()
        {
            var booking = await _bookingService.GetAllBookingsAsync();

            return Ok(booking);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if(booking == null)
            {
                NotFound();
            }

            return Ok(booking);
        }
        [HttpPost("CheckAvailability")]
        public async Task<ActionResult> CheckAvailability([FromBody] BookingDTO bookingDTO)
        {
            var isAvailable = await _bookingService.IsTableAvailableAsync(bookingDTO);
            if(isAvailable)
            {
                return Ok(new { Message = "Table is available" });
            }
            else
            {
                return BadRequest(new { Messagae = "Table is already booked" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookingDTO>> CreateBooking([FromBody] BookingDTO bookingDTO)
        {
            var newBooking = await _bookingService.BookTableAsync(bookingDTO);
            if(newBooking == null)
            {
                return BadRequest(new { Message = "Table is not available at the requested time" });

            }
            else
            {
                return CreatedAtAction(nameof(GetBookingById), new { id = newBooking.BookingId }, newBooking);
            }
        }
    }
}
