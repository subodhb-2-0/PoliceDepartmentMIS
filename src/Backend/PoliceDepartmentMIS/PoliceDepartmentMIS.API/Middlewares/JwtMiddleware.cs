using Microsoft.IdentityModel.Tokens;
using PoliceDepartmentMIS.Core.Dtos.ApplicationUser;
using PoliceDepartmentMIS.Service.Config;
using PoliceDepartmentMIS.Service.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace PoliceDepartmentMIS.API.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSettings _jwtSettings;
        public JwtMiddleware(RequestDelegate next, JwtSettings jwtSettings)
        {
            _next = next;
            _jwtSettings = jwtSettings;
        }
        public async Task Invoke(HttpContext context, IApplicationUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault();
            if (token != null)
            {
                var authHeader = AuthenticationHeaderValue.Parse(token);
                await attachUserToContext(context, userService, token?.Split(" ").Last(), _jwtSettings);
            }
            await _next(context);
        }
        private async Task attachUserToContext(HttpContext context, IApplicationUserService userService, string token, JwtSettings _jwtSetting)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSetting.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var userResponse = await userService.GetByIdAsync(userId);

            context.Items["User"] = userResponse.Data;
        }
    }
}
