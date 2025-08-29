using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }  
        public DateTime BookingTime { get; set; }
        public DateTime EndTime => BookingTime.AddHours(2);
        public int NumberOfGuests { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }

        public int TableId { get; set; }
        public Table Table { get; set; }

    }
}
