using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Dtos.Inmates;
using PoliceDepartmentMIS.Core.Interfaces;
using PoliceDepartmentMIS.Service.Services.Interfaces;

namespace PoliceDepartmentMIS.Service.Services
{
    public class InmatesService : IInmatesService
    {
        private readonly IInmatesRepository _inmatesRepository;
        public InmatesService(IInmatesRepository inmatesRepository)
        {
            _inmatesRepository = inmatesRepository;
        }
        public async Task<Response<int>> InsertInmatesAsync(InmateRequestDto inmate, int userId)
        {
            return await _inmatesRepository.InsertInmatesAsync(inmate, userId);
        }

        public async Task<Response<bool>> UpdateInmatesAsync(InmateRequestDto inmate, int id, int userId)
        {
            return await _inmatesRepository.UpdateInmatesAsync(inmate, id, userId);
        }

        public async Task<Response<bool>> DeleteInmatesAsync(int id, int userId)
        {
            return await _inmatesRepository.DeleteInmatesAsync(id, userId);
        }

        public async Task<GetAllList<InmateGetAllResponseDto>> GetInmatessAsync(FilterDto filterDto)
        {
            return await _inmatesRepository.GetInmatessAsync(filterDto);
        }

        public async Task<Response<InmateResponseDto>> GetInmateByIdAsync(int id)
        {
            Response<InmateResponseDto> response = new();
            response.Data =  await _inmatesRepository.GetInmateByIdAsync(id);
            if (response.Data != null) {
                response.IsSuccess = true;
                response.Message = "Inmate Found";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Inmate not Found";
            }
            return response;
        }
    }
}
