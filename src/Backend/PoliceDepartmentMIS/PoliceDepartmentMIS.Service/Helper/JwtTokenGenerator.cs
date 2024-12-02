using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PoliceDepartmentMIS.Service.Config;
using PoliceDepartmentMIS.Service.Helper.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PoliceDepartmentMIS.Service.Helper;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }
    public JwtSecurityToken GenerateJwt(List<Claim> Claims)
    {
        SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: Claims,
            expires: DateTime.UtcNow.AddDays(3),
            signingCredentials: signingCredentials);

        return jwt;
    }


    public string GetUserIdFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.ReadJwtToken(token);

        var userIdClaim = securityToken.Claims.FirstOrDefault(cl => cl.Type == ClaimTypes.NameIdentifier);

        if (userIdClaim is null)
        {
            return null;
        }

        return userIdClaim.Value;
    }
}
