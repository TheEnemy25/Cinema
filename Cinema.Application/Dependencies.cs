using Cinema.Application.Commands.Actor;
using Cinema.Application.Validation.Actor;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Enums;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

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
            services.AddFluentValidationAutoValidation(m =>
                m.ValidationStrategy = ValidationStrategy.Annotations);

            services.AddScoped<IValidator<CreateActorCommand>, CreateActorCommandValidator>();
            services.AddScoped<IValidator<UpdateActorCommand>, UpdateActorCommandValidator>();
            services.AddScoped<IValidator<DeleteActorCommand>, DeleteActorCommandValidator>();

            return services;
        }
    }
}