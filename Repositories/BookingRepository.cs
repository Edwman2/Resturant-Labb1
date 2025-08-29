using Microsoft.EntityFrameworkCore;
using Resturant_Labb1.Data;
using Resturant_Labb1.Models;
using Resturant_Labb1.Repositories.IRepository;

namespace Resturant_Labb1.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ResturantDbContext _context;

        public BookingRepository(ResturantDbContext context)
        {
            _context = context;    
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var rowsAffected = await _context.Bookings.Where(b => b.BookingId == id).ExecuteDeleteAsync();

            if(rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            var bookings = await _context.Bookings.ToListAsync();

            return bookings;   
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
