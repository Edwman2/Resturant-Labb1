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
        private readonly ICustomerRepository _customerRepository;


        public BookingService(IBookingRepository bookingRepo, ICustomerRepository customerRepository)
        {
            _bookingRepo = bookingRepo;
            _customerRepository = customerRepository;
        }
        public async Task<bool> IsTableAvailableAsync(BookingDTO bookingDTO)
        {
            var blockStart = bookingDTO.BookingTime.AddHours(-1);
            var blockEnd = bookingDTO.BookingTime.AddHours(2);

            var bookings = await _bookingRepo.GetAllBookingsAsync();

            return !bookings.Any(b =>
            b.TableId == bookingDTO.TableId &&
            b.BookingTime.AddHours(-1) < blockEnd &&
            b.EndTime > blockStart
            );
        }
        public async Task<BookingDTO> BookTableAsync(BookingDTO bookingDTO)
        {
            if (!await IsTableAvailableAsync(bookingDTO))
                return null;
            var customer = new Customer
            {
                Name = bookingDTO.Name,
                Lastname = bookingDTO.Lastname,
                Phonenumber = bookingDTO.Phonenumber,
                Email = bookingDTO.Email
            };

            await _customerRepository.AddCustomerAsync(customer);
            await _customerRepository.SaveChangesAsync();

            var booking = new Booking
            {
                BookingTime = bookingDTO.BookingTime,
                NumberOfGuests = bookingDTO.NumberOfGuests,
                CustomerId = customer.CustomerId,
                TableId = bookingDTO.TableId
            };

            var newBooking = await _bookingRepo.AddBookingAsync(booking);
            await _bookingRepo.SaveChangesAsync();

            return new BookingDTO
            {
                BookingId = newBooking.BookingId,
                BookingTime = newBooking.BookingTime,
                NumberOfGuests = newBooking.NumberOfGuests,
                CustomerId = newBooking.CustomerId,
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
