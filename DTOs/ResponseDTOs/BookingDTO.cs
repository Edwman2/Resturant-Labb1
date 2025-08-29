namespace Resturant_Labb1.DTOs.ResponseDTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime EndTime { get; set; }

        public int NumberOfGuests { get; set; }
        public int TableId { get; set; }

        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Phonenumber { get; set; }
    }
}
