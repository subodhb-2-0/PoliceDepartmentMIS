using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartmentMIS.Core.Dtos.Booking;
using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Service.Services.Interfaces;

namespace PoliceDepartmentMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : BaseController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [Authorize]
        [HttpPost("InsertBooking")]
        public async Task<IActionResult> InsertBooking([FromBody] BookingRequestDto booking)
        {
            var result = await _bookingService.InsertBookingAsync(booking, UserId);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("UpdateBooking/{id}")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingRequestDto booking, int id)
        {
            var result = await _bookingService.UpdateBookingAsync(booking, id, UserId);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("DeleteBooking/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteBookingAsync(id, UserId);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetAllBookings")]
        public async Task<IActionResult> GetBookings([FromQuery] FilterDto filterDto)
        {
            var result = await _bookingService.GetBookingsAsync(filterDto);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetBookingById/{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var result = await _bookingService.GetBookingByIdAsync(id);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("GetBookingByEmployeeId/{id}")]
        public async Task<IActionResult> GetBookingByEmployeeId(int id)
        {
            var result = await _bookingService.GetBookingByEmployeeId(id);
            return Ok(result);
        }
    }
}
