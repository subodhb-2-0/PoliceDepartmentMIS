using PoliceDepartmentMIS.Core.Domain;
using PoliceDepartmentMIS.Core.Dtos.ApplicationUser;
using PoliceDepartmentMIS.Core.Dtos.Common;

namespace PoliceDepartmentMIS.Core.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<int> InsertApplicationUserAsync(UserRegisterDto dto);
        Task<bool> UpdateApplicationUserAsync(ApplicationUser applicationuser);
        Task<bool> DeleteApplicationUserAsync(int applicationuserId, int updatedBy);
        Task<List<ApplicationUser>> GetApplicationUsersAsync(FilterDto filterDto);
        Task<Response<ApplicationUser>> GetApplicationUserByIdAsync(int applicationuserId);
        Task<Response<int>> ValidateUserAsync(UserLoginDto dto);
    }
}
