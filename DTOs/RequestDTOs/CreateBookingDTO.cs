using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.DTOs.RequestDTOs
{
    public class CreateBookingDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Firstname has to contain at least on character.")]
        public string Firstname { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Lastname has to contain at least one character")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Phonenumber has to be inserted")]
        public string Phonenumber { get; set; }
        public DateTime BookingTime { get; set; }
        [Required]
        [Range(1,10, ErrorMessage = "Has to insert at least one guest")]
        public int NumberOfGuests { get; set; }
    }
}
