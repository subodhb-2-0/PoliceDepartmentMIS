using FakeItEasy;
using FluentAssertions;
using PoliceDepartmentMIS.Core.Domain;
using PoliceDepartmentMIS.Core.Dtos.ApplicationUser;
using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Interfaces;
using PoliceDepartmentMIS.Service.Helper.Interface;
using PoliceDepartmentMIS.Service.Services;

namespace PoliceDepartmentMIS.Test.ApplicationUserTest
{
    public class ApplicationUserServiceTest
    {
        private readonly ApplicationUserService _applicationUserService;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public ApplicationUserServiceTest()
        {
            _applicationUserRepository = A.Fake<IApplicationUserRepository>();
            _jwtTokenGenerator = A.Fake<IJwtTokenGenerator>();

            //SUT
            _applicationUserService = new ApplicationUserService(_applicationUserRepository, _jwtTokenGenerator);
        }
        [Fact]
        public async Task ApplicationUserService_AuthenticateAsync_ReturnsToken()
        {
            var validateResponse = A.Fake<Response<int>>();
            var userDto = A.Fake<UserLoginDto>();
            A.CallTo(() => _applicationUserRepository.ValidateUserAsync(userDto)).Returns(validateResponse);
            var result = await _applicationUserService.AuthenticateAsync(userDto);


            result.Should().NotBeNull();
            result.Should().BeOfType<Response<string>>();
        }

        [Theory]
        [InlineData(1)]
        public async Task ApplicationUserService_GetByIdAsync_ReturnsApplicationUser(int Id)
        {
            var userData = A.Fake<ApplicationUser>();
            var userResponse = new Response<ApplicationUser>
            {
                Data = userData
            };
            A.CallTo(()=>_applicationUserRepository.GetApplicationUserByIdAsync(Id)).Returns(userResponse);
            var result = await _applicationUserService.GetByIdAsync(Id);

            result.Should().NotBeNull();
            result.Should().BeOfType<Response<ApplicationUser>>();
        }
    }
}
