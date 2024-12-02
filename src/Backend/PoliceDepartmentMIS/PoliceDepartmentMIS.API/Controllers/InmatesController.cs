using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartmentMIS.Core.Dtos.Common;
using PoliceDepartmentMIS.Core.Dtos.Inmates;
using PoliceDepartmentMIS.Service.Services.Interfaces;

namespace PoliceDepartmentMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmatesController : BaseController
    {
        private readonly IInmatesService _inmatesService;

        public InmatesController(IInmatesService inmatesService)
        {
            _inmatesService = inmatesService;
        }
        [Authorize]
        [HttpPost("InsertInmates")]
        public async Task<IActionResult> InsertInmates([FromBody] InmateRequestDto inmate)
        {
            var result = await _inmatesService.InsertInmatesAsync(inmate, UserId);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("UpdateInamtes/{id}")]
        public async Task<IActionResult> UpdateInmates([FromBody] InmateRequestDto inmate, int id)
        {
            var result = await _inmatesService.UpdateInmatesAsync(inmate, id, UserId);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("DeleteInamte/{id}")]
        public async Task<IActionResult> DeleteInmates(int id)
        {
            var result = await _inmatesService.DeleteInmatesAsync(id, UserId);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetAllInmates")]
        public async Task<IActionResult> GetInmates([FromQuery] FilterDto filterDto)
        {
            var result = await _inmatesService.GetInmatessAsync(filterDto);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetInmateById/{id}")]
        public async Task<IActionResult> GetInmateById(int id)
        {
            var result = await _inmatesService.GetInmateByIdAsync(id);
            return Ok(result);
        }
    }
}
