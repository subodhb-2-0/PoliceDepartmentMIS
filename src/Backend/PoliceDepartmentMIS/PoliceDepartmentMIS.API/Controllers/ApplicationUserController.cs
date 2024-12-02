using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliceDepartmentMIS.Core.Dtos.ApplicationUser;
using PoliceDepartmentMIS.Service.Services.Interfaces;

namespace PoliceDepartmentMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : BaseController
    {
        private readonly IApplicationUserService _applicationUserService;

        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        [AllowAnonymous]
        [HttpPost("AuthenticateAsync")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserLoginDto dto)
        {
            var response = await _applicationUserService.AuthenticateAsync(dto);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("RegisterAsync")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterDto dto)
        {
            var result = await _applicationUserService.RegisterAsync(dto);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetUserByIdAsync")]
        public async Task<IActionResult> GetUserByIdAsync(int Id)
        {
            return Ok(await _applicationUserService.GetByIdAsync(Id));
        }
    }
}
