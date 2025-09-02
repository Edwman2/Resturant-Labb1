using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resturant_Labb1.DTOs.RequestDTOs;
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
        private readonly IResturantTableService _tableService;

        public BookingController(IBookingService bookingService,IResturantTableService tableService)
        {
            _bookingService = bookingService;
            _tableService = tableService;
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
        public async Task<ActionResult> CheckAvailability([FromBody] CheckBookingDTO checkDTO)
        {
            try
            {
                var isAvailable = await _bookingService.FindAvailableTable(checkDTO);

                if (isAvailable == null)
                {
                    return BadRequest(new { Message = "No available table at the time or too many guests" });
                }

                return Ok(new { Message = "Table is available",
                Table = isAvailable});

            }
            catch(Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occured", Details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookingDTO>> CreateBooking([FromBody] CreateBookingDTO bookingDTO)
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
