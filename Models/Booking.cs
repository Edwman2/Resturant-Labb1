using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public DateTime BookingTime { get; set; }
        public int NumberOfGuests { get; set; }

        public DateTime EndTime => BookingTime.AddHours(2);

        public int TableId { get; set; }
        public ResturantTable Table { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
