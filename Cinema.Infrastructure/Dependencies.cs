using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cinema.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddMaps(typeof(Dependencies).Assembly), Assembly.Load("Cinema.Application"));

            return services;
        }
    }
}