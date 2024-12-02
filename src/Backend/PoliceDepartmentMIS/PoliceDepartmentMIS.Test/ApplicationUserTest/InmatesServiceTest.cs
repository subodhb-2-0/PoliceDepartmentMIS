using FakeItEasy;
using FluentAssertions;
using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Dtos.Inmates;
using PoliceDepartmentMIS.Core.Interfaces;
using PoliceDepartmentMIS.Service.Services;

namespace PoliceDepartmentMIS.Test.ApplicationUserTest
{
    public class InmatesServiceTest
    {
        private readonly InmatesService _service;
        private readonly IInmatesRepository _inmatesRepository;
        public InmatesServiceTest()
        {
            _inmatesRepository = A.Fake<IInmatesRepository>();
            _service = new InmatesService(_inmatesRepository);
        }
        [Theory]
        [InlineData(1,1)]
        public async Task InmatesService_InsertInmatesAsync_ReturnsId(int userId, int data)
        {
            var validateResponse = new Response<int>()
            {
                Data = data,
            };
            var dto = A.Fake<InmateRequestDto>();
            A.CallTo(() => _inmatesRepository.InsertInmatesAsync(dto, userId)).Returns(validateResponse);
            var result = await _service.InsertInmatesAsync(dto, userId);

            result.Should().NotBeNull();
            result.Should().BeOfType<Response<int>>();
        }

        [Theory]
        [InlineData(1, 1, true)]
        public async Task InmatesService_UpdateInmatesAsync_ReturnsBool(int userId, int id, bool isSuccess)
        {
            var validateResponse = new Response<bool>
            {
                Data = isSuccess,
            };
            var dto = A.Fake<InmateRequestDto>();
            A.CallTo(() => _inmatesRepository.UpdateInmatesAsync(dto, id, userId)).Returns(validateResponse);
            var result = await _service.UpdateInmatesAsync(dto, id, userId);

            result.Should().NotBeNull();
            result.Should().BeOfType<Response<bool>>();
            result.Data.Should().Be(isSuccess);
        }

        [Theory]
        [InlineData(1, 1, true)]
        public async Task InmatesService_DeleteInmatesAsync_ReturnsBool(int userId, int id, bool isSuccess)
        {
            var validateResponse = new Response<bool>
            {
                Data = isSuccess,
            };
            A.CallTo(() => _inmatesRepository.DeleteInmatesAsync(id, userId)).Returns(validateResponse);
            var result = await _service.DeleteInmatesAsync(id, userId);

            result.Should().NotBeNull();
            result.Should().BeOfType<Response<bool>>();
            result.Data.Should().Be(isSuccess);
        }

        [Fact]
        public async Task InmatesService_GetInmatessAsync_ReturnsGetAllList()
        {
            var filterDto = A.Fake<FilterDto>();

            var dataList = A.Fake<List<InmateGetAllResponseDto>>();
            var validateResponse = new GetAllList<InmateGetAllResponseDto>
            {
                DataList = dataList,
            };
            A.CallTo(() => _inmatesRepository.GetInmatessAsync(filterDto)).Returns(validateResponse);
            var result = await _service.GetInmatessAsync(filterDto);

            result.Should().NotBeNull();
            result.Should().BeOfType<GetAllList<InmateGetAllResponseDto>>();
        }

        [Theory]
        [InlineData(1)]
        public async Task InmatesService_GetInmateByIdAsync_ReturnsInmateResponse(int Id)
        {
            var data = A.Fake<InmateResponseDto>();
            var validateResponse = new Response<InmateResponseDto>
            {
                Data = data,
            };
            A.CallTo(() => _inmatesRepository.GetInmateByIdAsync(Id)).Returns(data);
            var result = await _service.GetInmateByIdAsync(Id);

            result.Should().NotBeNull();
            result.Should().BeOfType<Response<InmateResponseDto>>();
        }
    }
}
