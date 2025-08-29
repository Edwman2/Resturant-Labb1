using Resturant_Labb1.Models;

namespace Resturant_Labb1.Repositories.IRepository
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> AddBookingAsync(Booking booking);
        Task<bool> DeleteBookingAsync(int id);
        Task SaveChangesAsync();
    }
}
