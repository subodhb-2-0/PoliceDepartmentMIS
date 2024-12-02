using PoliceDepartmentMIS.Core.Domain;
using PoliceDepartmentMIS.Core.Dtos.ApplicationUser;
using PoliceDepartmentMIS.Core.Dtos.Common;

namespace PoliceDepartmentMIS.Service.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<Response<ApplicationUser>> GetByIdAsync(int Id);
        Task<Response<string>> AuthenticateAsync(UserLoginDto dto);
        Task<Response<string>> RegisterAsync(UserRegisterDto dto);

    }
}
