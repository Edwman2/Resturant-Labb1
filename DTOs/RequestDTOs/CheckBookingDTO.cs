using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.DTOs.RequestDTOs
{
    public class CheckBookingDTO
    {
        [Required]
        public DateTime BookingTime { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="You have to put in at least one guest")]
        public int? NumberOfGuests { get; set; }
    }
}
