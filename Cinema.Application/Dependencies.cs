using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cinema.Application
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterMediatRAndHanlders(this IServiceCollection services)
        {
            services.AddMediatR(m =>
                m.RegisterServicesFromAssembly(typeof(Dependencies).Assembly));

            return services;
        }
    }
}