using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Dtos.Booking;

namespace PoliceDepartmentMIS.Core.Interfaces
{
    public interface IBookingRepository
    {
        Task<Response<int>> InsertBookingAsync(BookingRequestDto Booking, int userId);
        Task<Response<bool>> UpdateBookingAsync(BookingRequestDto Booking, int Id, int userId);
        Task<Response<bool>> DeleteBookingAsync(int Id, int userId);
        Task<GetAllList<BookingGetAllResponseDto>> GetBookingsAsync(FilterDto filterDto);
        Task<BookingResponseDto> GetBookingByIdAsync(int Id);
        Task<GetAllList<BookingGetAllResponseDto>> GetBookingByEmployeeId(int EmployeeId);
    }
}
