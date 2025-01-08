using Microsoft.Extensions.DependencyInjection;

namespace KindyCity.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedDI(this IServiceCollection services)
        {
            return services;
        }
    }
}
