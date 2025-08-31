namespace Resturant_Labb1.DTOs.RequestDTOs
{
    public class CheckBookingAvailabilityDTO
    {
        public DateTime BookingTime { get; set; }
        
        public int NumberOfGuests { get; set; }
    }
}
