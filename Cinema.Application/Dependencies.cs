using Cinema.Application.Commands.Actor;
using Cinema.Application.Validation.Actor;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

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

        public static IServiceCollection RegisterCommandValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateActorCommand>, CreateActorCommandValidator>();
            services.AddTransient<IValidator<UpdateActorCommand>, UpdateActorCommandValidator>();
            services.AddTransient<IValidator<DeleteActorCommand>, DeleteActorCommandValidator>();

            return services;
        }
    }
}