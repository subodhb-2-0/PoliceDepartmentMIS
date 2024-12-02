using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PoliceDepartmentMIS.Service.Config;
using PoliceDepartmentMIS.Service.Helper;
using PoliceDepartmentMIS.Service.Helper.Interface;
using PoliceDepartmentMIS.Service.Services;
using PoliceDepartmentMIS.Service.Services.Interfaces;
namespace PoliceDepartmentMIS.Service.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAutoMapper(typeof(MappingProfile));

            service.AddSingleton<JwtSettings>(option => new JwtSettings()
            {
                ValidIssuer = configuration["JwtSettings:ValidIssuer"],
                ValidAudience = configuration["JwtSettings:ValidAudience"],
                Secret = configuration["JwtSettings:Secret"]
            });

            service.AddScoped<IApplicationUserService, ApplicationUserService>();
            service.AddScoped<IBookingService, BookingService>();
            service.AddScoped<IInmatesService, InmatesService>();
            service.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            return service;
        }
    }
}
