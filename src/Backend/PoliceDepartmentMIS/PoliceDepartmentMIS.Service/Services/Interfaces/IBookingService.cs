using PoliceDepartmentMIS.Core.Dtos.Booking;
using PoliceDepartmentMIS.Core.Dtos.Common;

namespace PoliceDepartmentMIS.Service.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Response<int>> InsertBookingAsync(BookingRequestDto booking, int userId);
        Task<Response<bool>> UpdateBookingAsync(BookingRequestDto booking, int id, int userId);
        Task<Response<bool>> DeleteBookingAsync(int id, int userId);
        Task<GetAllList<BookingGetAllResponseDto>> GetBookingsAsync(FilterDto filterDto);
        Task<GetAllList<BookingGetAllResponseDto>> GetBookingByEmployeeId(int EmployeeId);
        Task<Response<BookingResponseDto>> GetBookingByIdAsync(int id);
    }
}
