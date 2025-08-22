namespace Resturant_Labb1.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int TableNumber { get; set; }

        public int Seats { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
