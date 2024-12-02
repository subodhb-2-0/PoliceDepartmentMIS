using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PoliceDepartmentMIS.Core.Interfaces;
using PoliceDepartmentMIS.Data.Config;
using PoliceDepartmentMIS.Data.Repositories;
namespace PoliceDepartmentMIS.Data.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton<ConnectionString>(option => new ConnectionString()
            {
                MySqlConnectionString = configuration.GetConnectionString("DefaultMySqlConnection")
            });

            service.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            service.AddScoped<IBookingRepository, BookingRepository>();
            service.AddScoped<IInmatesRepository, InmatesRepository>();

            return service;
        }
    }
}
