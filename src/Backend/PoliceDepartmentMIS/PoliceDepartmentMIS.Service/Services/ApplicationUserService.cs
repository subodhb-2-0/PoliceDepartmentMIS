using PoliceDepartmentMIS.Core.Domain;
using PoliceDepartmentMIS.Core.Dtos.ApplicationUser;
using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Interfaces;
using PoliceDepartmentMIS.Service.Helper;
using PoliceDepartmentMIS.Service.Helper.Interface;
using PoliceDepartmentMIS.Service.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PoliceDepartmentMIS.Service.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _repository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public ApplicationUserService(IApplicationUserRepository repository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _repository = repository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Response<string>> AuthenticateAsync(UserLoginDto dto)
        {
            Response<string> response = new();
            var validateResponse = await _repository.ValidateUserAsync(dto);
            if (!validateResponse.IsSuccess)
            {
                response.IsSuccess = false;
                response.Message = "Invalid Credentials.";
                return response;
            }
            if(Security.VerifyHash(dto.Password, validateResponse.Message))
            {
                var userResponse = await _repository.GetApplicationUserByIdAsync(validateResponse.Data);

                response.IsSuccess = true;
                response.Data = BuildJwtResponseAsync(userResponse.Data);
                response.Message = "User Authenticated Successfully";
                return response;
            }
            response.Message = "Invalid Credentials.";
            response.IsSuccess = false;
            return response;
        }

        public async Task<Response<ApplicationUser>> GetByIdAsync(int Id)
        {
            var userResponse = await _repository.GetApplicationUserByIdAsync(Id);
            return userResponse;
        }

        public async Task<Response<string>> RegisterAsync(UserRegisterDto dto)
        {
            Response<string> response = new();
            dto.Password = Security.HashPassword(dto.Password);
            var newUserId = await _repository.InsertApplicationUserAsync(dto);
            if(newUserId < 1)
            {
                response.IsSuccess = false;
                response.Message = "Error Occured";
                return response;
            }
            var user = await _repository.GetApplicationUserByIdAsync(newUserId);
            response.IsSuccess = true;
            response.Data = BuildJwtResponseAsync(user.Data);
            return response;
        }



        private string BuildJwtResponseAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone)
            };

            var securityToken = _jwtTokenGenerator.GenerateJwt(claims);
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
