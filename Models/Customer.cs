using System.ComponentModel.DataAnnotations;

namespace Resturant_Labb1.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
