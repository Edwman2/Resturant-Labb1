namespace Resturant_Labb1.DTOs.ResponseDTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public DateTime BookingTime { get; set; }
        public int NumberOfGuests { get; set; }
        public int TableId { get; set; }
        public int CustomerId { get; set; }

        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Phonenumber { get; set; }
        public string? Email { get; set; }
    }
}
