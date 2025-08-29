namespace Resturant_Labb1.DTOs.RequestDTOs
{
    public class CreateBookingDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public int TableId { get; set; }
        public DateTime BookingTime { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
