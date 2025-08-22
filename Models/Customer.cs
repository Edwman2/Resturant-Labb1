namespace Resturant_Labb1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Phonenumber { get; set; }
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
