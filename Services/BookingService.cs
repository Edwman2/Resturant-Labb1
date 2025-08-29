using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Models;
using Resturant_Labb1.Repositories.IRepository;
using Resturant_Labb1.Services.IServices;
using System.Runtime.InteropServices;

namespace Resturant_Labb1.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IResturantTableRepository _tableRepo;


        public BookingService(IBookingRepository bookingRepo, IResturantTableRepository tableRepo)
        {
            _bookingRepo = bookingRepo;
            _tableRepo = tableRepo;
        }

        public async Task<TableDTO> FindAvailableTable(BookingDTO  bookingDTO)
        {
            var tables = await _tableRepo.GetAllResturantTablesAsync();
            var bookings = await _bookingRepo.GetAllBookingsAsync();

            var blockStart = bookingDTO.BookingTime.AddHours(-1);
            var blockEnd = bookingDTO.BookingTime.AddHours(2);

            foreach (var table in tables)
            {
                if (bookingDTO.NumberOfGuests > table.Seats)
                    continue;

                bool occupied = bookings.Any(b =>
                b.TableId == table.TableId &&
                b.BookingTime.AddHours(-1) < blockEnd &&
                b.EndTime > blockStart);

                if(!occupied)
                {
                    return new TableDTO { TableId = table.TableId, Seats = table.Seats };
                }

               
            }
            return null;
        }
        public async Task<BookingDTO> BookTableAsync(BookingDTO bookingDTO)
        {
            var availableTable = await FindAvailableTable(bookingDTO);
            if(availableTable == null)
            {
                return null;
            }

            var booking = new Booking
            {
                BookingTime = bookingDTO.BookingTime,
                NumberOfGuests = bookingDTO.NumberOfGuests,
                Firstname = bookingDTO.Firstname,
                Lastname = bookingDTO.Lastname,
                TableId = availableTable.TableId,
            };

            var newBooking = await _bookingRepo.AddBookingAsync(booking);
            await _bookingRepo.SaveChangesAsync();

            return new BookingDTO
            {
                BookingId = newBooking.BookingId,
                BookingTime = newBooking.BookingTime,
                NumberOfGuests = newBooking.NumberOfGuests,
                Firstname = newBooking.Firstname,
                Lastname = newBooking.Lastname,
                TableId = newBooking.TableId
                
            };
        }

        public async Task<bool> DeleteBookingAsync(int BookingId)
        {
            return await _bookingRepo.DeleteBookingAsync(BookingId);
        }

        public async Task<List<BookingDTO>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepo.GetAllBookingsAsync();

            var bookingDTO = bookings.Select(b => new BookingDTO
            {
                BookingId = b.BookingId,
                BookingTime = b.BookingTime,
                NumberOfGuests = b.NumberOfGuests
            }).ToList();

            return bookingDTO;
        }

        public async Task<BookingDTO> GetBookingByIdAsync(int BookingId)
        {
            var bookings = await _bookingRepo.GetBookingByIdAsync(BookingId);

            if(bookings == null)
            {
                return null;
            }

            var bookingDTO = new BookingDTO
            {
                BookingId = bookings.BookingId,
                BookingTime = bookings.BookingTime,
                NumberOfGuests = bookings.NumberOfGuests
            };

            return bookingDTO;
        }

        public async Task<bool> UpdateBookingAsync(int BookingId, UpdateBookingDTO updateBookingDTO)
        {
            var booking = await _bookingRepo.GetBookingByIdAsync(BookingId);
            if(booking == null)
            {
                return false;
            }
            booking.BookingTime = updateBookingDTO.BookingTime;
            booking.NumberOfGuests = updateBookingDTO.NumberOfGuests;

            await _bookingRepo.SaveChangesAsync();

            return true;

        }
    }
}
