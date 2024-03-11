using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddMaps(typeof(Dependencies).Assembly));

            return services;
        }
    }
}