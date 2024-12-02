using PoliceDepartmentMIS.Core.Domain;
using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Dtos.Inmates;

namespace PoliceDepartmentMIS.Core.Interfaces
{
    public interface IInmatesRepository
    {
        Task<Response<int>> InsertInmatesAsync(InmateRequestDto inmate, int userId);
        Task<Response<bool>> UpdateInmatesAsync(InmateRequestDto inmate, int Id, int userId);
        Task<Response<bool>> DeleteInmatesAsync(int Id, int userId);
        Task<GetAllList<InmateGetAllResponseDto>> GetInmatessAsync(FilterDto filterDto);
        Task<InmateResponseDto> GetInmateByIdAsync(int Id);
    }
}
