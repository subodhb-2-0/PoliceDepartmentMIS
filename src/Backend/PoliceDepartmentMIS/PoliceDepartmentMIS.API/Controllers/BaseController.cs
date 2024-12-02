using Microsoft.AspNetCore.Mvc;
using PoliceDepartmentMIS.Core.Domain;

namespace PoliceDepartmentMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private int _userId;
        public int UserId
        {
            get
            {
                if(_userId > 0)
                {
                    return _userId;
                }
                var user = (ApplicationUser)HttpContext.Items["User"];
                if (user == null)
                {
                    _userId = 0;
                }
                _userId = user.Id;
                return _userId;
            }
        }
    }
}
