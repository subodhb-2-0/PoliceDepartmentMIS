using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PoliceDepartmentMIS.Service.Helper.Interface
{
    public interface IJwtTokenGenerator
    {
        JwtSecurityToken GenerateJwt(List<Claim> Claims);
        string GetUserIdFromToken(string token);
    }
}
