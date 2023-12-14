using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cinema.Applicaton
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterMediatRAndHanlders(this IServiceCollection services)
        {
            services.AddMediatR(m =>
                m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}