using PoliceDepartmentMIS.Core.Dtos.Booking;
using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Interfaces;
using PoliceDepartmentMIS.Service.Services.Interfaces;

namespace PoliceDepartmentMIS.Service.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        // Method to insert a new booking
        public async Task<Response<int>> InsertBookingAsync(BookingRequestDto booking, int userId)
        {
            return await _bookingRepository.InsertBookingAsync(booking, userId);
        }

        // Method to update an existing booking
        public async Task<Response<bool>> UpdateBookingAsync(BookingRequestDto booking, int id, int userId)
        {
            return await _bookingRepository.UpdateBookingAsync(booking, id, userId);
        }

        // Method to delete a booking (soft delete)
        public async Task<Response<bool>> DeleteBookingAsync(int id, int userId)
        {
            return await _bookingRepository.DeleteBookingAsync(id, userId);
        }

        // Method to fetch a list of bookings based on filters
        public async Task<GetAllList<BookingGetAllResponseDto>> GetBookingsAsync(FilterDto filterDto)
        {
            return await _bookingRepository.GetBookingsAsync(filterDto);
        }

        // Method to get a booking by ID
        public async Task<Response<BookingResponseDto>> GetBookingByIdAsync(int id)
        {
            Response<BookingResponseDto> response = new();
            response.Data = await _bookingRepository.GetBookingByIdAsync(id);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Booking Found";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Booking not Found";
            }

            return response;
        }

        public async Task<GetAllList<BookingGetAllResponseDto>> GetBookingByEmployeeId(int EmployeeId)
        {
            return await _bookingRepository.GetBookingByEmployeeId(EmployeeId);
        }
    }
}
