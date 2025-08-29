using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;

namespace Resturant_Labb1.Services.IServices
{
    public interface IBookingService
    {
        Task<List<BookingDTO>> GetAllBookingsAsync();
        Task<BookingDTO> GetBookingByIdAsync(int BookingId);
        Task<bool> UpdateBookingAsync(int BookingId, UpdateBookingDTO updateBookingDTO );
        Task<bool> DeleteBookingAsync(int BookingId);
        Task<bool> IsTableAvailableAsync(BookingDTO bookingDTO);
        Task<BookingDTO?> BookTableAsync(BookingDTO bookingDTO);
    }
}
