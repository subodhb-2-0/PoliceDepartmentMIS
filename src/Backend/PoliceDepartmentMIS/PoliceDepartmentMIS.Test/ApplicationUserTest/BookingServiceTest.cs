using FakeItEasy;
using FluentAssertions;
using PoliceDepartmentMIS.Core.Dtos.Booking;
using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Interfaces;
using PoliceDepartmentMIS.Service.Services;

namespace PoliceDepartmentMIS.Test.ApplicationUserTest
{
    public class BookingServiceTest
    {
        private readonly BookingService _service;
        private readonly IBookingRepository _repository;

        public BookingServiceTest()
        {
            _repository = A.Fake<IBookingRepository>();
            _service = new BookingService(_repository);
        }

        [Theory]
        [InlineData(1, 1)]
        public async Task BookingsService_InsertBookingsAsync_ReturnsId(int userId, int data)
        {
            var validateResponse = new Response<int>()
            {
                Data = data,
            };
            var dto = A.Fake<BookingRequestDto>();
            A.CallTo(() => _repository.InsertBookingAsync(dto, userId)).Returns(validateResponse);
            var result = await _service.InsertBookingAsync(dto, userId);

            result.Should().NotBeNull();
            result.Should().BeOfType<Response<int>>();
        }

        [Theory]
        [InlineData(1, 1, true)]
        public async Task BookingsService_UpdateBookingsAsync_ReturnsBool(int userId, int id, bool isSuccess)
        {
            var validateResponse = new Response<bool>
            {
                Data = isSuccess,
            };
            var dto = A.Fake<BookingRequestDto>();
            A.CallTo(() => _repository.UpdateBookingAsync(dto, id, userId)).Returns(validateResponse);
            var result = await _service.UpdateBookingAsync(dto, id, userId);

            result.Should().NotBeNull();
            result.Should().BeOfType<Response<bool>>();
            result.Data.Should().Be(isSuccess);
        }

        [Theory]
        [InlineData(1, 1, true)]
        public async Task BookingsService_DeleteBookingsAsync_ReturnsBool(int userId, int id, bool isSuccess)
        {
            var validateResponse = new Response<bool>
            {
                Data = isSuccess,
            };
            A.CallTo(() => _repository.DeleteBookingAsync(id, userId)).Returns(validateResponse);
            var result = await _service.DeleteBookingAsync(id, userId);

            result.Should().NotBeNull();
            result.Should().BeOfType<Response<bool>>();
            result.Data.Should().Be(isSuccess);
        }

        [Fact]
        public async Task BookingsService_GetBookingssAsync_ReturnsGetAllList()
        {
            var filterDto = A.Fake<FilterDto>();

            var dataList = A.Fake<List<BookingGetAllResponseDto>>();
            var validateResponse = new GetAllList<BookingGetAllResponseDto>
            {
                DataList = dataList,
            };
            A.CallTo(() => _repository.GetBookingsAsync(filterDto)).Returns(validateResponse);
            var result = await _service.GetBookingsAsync(filterDto);

            result.Should().NotBeNull();
            result.Should().BeOfType<GetAllList<BookingGetAllResponseDto>>();
        }

        [Theory]
        [InlineData(1)]
        public async Task BookingsService_GetBookingByIdAsync_ReturnsBookingResponse(int Id)
        {
            var data = A.Fake<BookingResponseDto>();
            var validateResponse = new Response<BookingResponseDto>
            {
                Data = data,
            };
            A.CallTo(() => _repository.GetBookingByIdAsync(Id)).Returns(data);
            var result = await _service.GetBookingByIdAsync(Id);

            result.Should().NotBeNull();
            result.Should().BeOfType<Response<BookingResponseDto>>();
        }
    }
}
