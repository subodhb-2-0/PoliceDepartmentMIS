using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Dtos.Inmates;

namespace PoliceDepartmentMIS.Service.Services.Interfaces
{
    public interface IInmatesService
    {
        Task<Response<int>> InsertInmatesAsync(InmateRequestDto inmate, int userId);
        Task<Response<bool>> UpdateInmatesAsync(InmateRequestDto inmate, int id, int userId);
        Task<Response<bool>> DeleteInmatesAsync(int id, int userId);
        Task<GetAllList<InmateGetAllResponseDto>> GetInmatessAsync(FilterDto filterDto);
        Task<Response<InmateResponseDto>> GetInmateByIdAsync(int id);
    }
}
