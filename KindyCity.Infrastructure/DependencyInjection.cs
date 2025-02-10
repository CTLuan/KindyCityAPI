using KindyCity.Application.Interfaces;
using KindyCity.Domain.Interfaces;
using KindyCity.Infrastructure.Data;
using KindyCity.Infrastructure.Repositories;
using KindyCity.Infrastructure.Services;
using KindyCity.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KindyCity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<KindyCityContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(KindyCity))));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
