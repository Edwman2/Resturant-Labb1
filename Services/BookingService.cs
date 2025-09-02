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

        public async Task<TableDTO> FindAvailableTable(CheckBookingDTO checkDTO)
        {
            var tables = await _tableRepo.GetAllResturantTablesAsync();
            var bookings = await _bookingRepo.GetAllBookingsAsync();

            

            foreach (var table in tables)
            {
                if (checkDTO.NumberOfGuests > table.Seats)
                    continue;

                bool occupied = bookings.Any(b =>
                b.TableId == table.TableId &&
                checkDTO.BookingTime < b.EndTime &&
                checkDTO.BookingTime.AddHours(2) > b.BookingTime);


                if(!occupied)
                {
                    return new TableDTO { TableId = table.TableId, TableNumber = table.TableNumber, Seats = table.Seats };
                }

               
            }
            return null;
        }
        public async Task<BookingDTO> BookTableAsync(CreateBookingDTO bookingDTO)
        {
            var check = new CheckBookingDTO
            {
                BookingTime = bookingDTO.BookingTime,
                NumberOfGuests = bookingDTO.NumberOfGuests
            };

            var availableTable = await FindAvailableTable(check);
            if(availableTable == null)
            {
                return null;
            }

            var booking = new Booking
            {
                BookingTime = bookingDTO.BookingTime,
                EndTime = bookingDTO.BookingTime.AddHours(2),
                NumberOfGuests = bookingDTO.NumberOfGuests,
                Firstname = bookingDTO.Firstname,
                Lastname = bookingDTO.Lastname,
                Phonenumber = bookingDTO.Phonenumber,
                TableId = availableTable.TableId
                
            };

            var newBooking = await _bookingRepo.AddBookingAsync(booking);
            await _bookingRepo.SaveChangesAsync();

            return new BookingDTO
            {
                BookingId = newBooking.BookingId,
                BookingTime = newBooking.BookingTime,
                EndTime = newBooking.EndTime,
                NumberOfGuests = newBooking.NumberOfGuests,
                Firstname = newBooking.Firstname,
                Lastname = newBooking.Lastname,
                Phonenumber = newBooking.Phonenumber,
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
                EndTime = b.EndTime,
                NumberOfGuests = b.NumberOfGuests,
                TableId = b.TableId,
                Firstname = b.Firstname,
                Lastname = b.Lastname,
                Phonenumber = b.Phonenumber
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
                EndTime = bookings.EndTime,
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
            booking.BookingTime = updateBookingDTO.BookingTime.AddHours(2);
            booking.NumberOfGuests = updateBookingDTO.NumberOfGuests;

            await _bookingRepo.SaveChangesAsync();

            return true;

        }
    }
}
