using KindyCity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KindyCity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KindyCityContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(KindyCity))));

            return services;
        }
    }
}
