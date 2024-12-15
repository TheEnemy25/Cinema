using Cinema.Application.Commands.Actor;
using Cinema.Application.Commands.Movie;
using Cinema.Application.Queries.Actor;
using Cinema.Application.Queries.Movie;
using Cinema.Application.Validation.Actor.CommandValidator;
using Cinema.Application.Validation.Actor.QueryValidator;
using Cinema.Application.Validation.Movie.CommandValidator;
using Cinema.Application.Validation.Movie.QueryValidator;
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

        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(m =>
                m.ValidationStrategy = ValidationStrategy.Annotations);

            services.AddScoped<IValidator<CreateActorCommand>, CreateActorCommandValidator>();
            services.AddScoped<IValidator<DeleteActorCommand>, DeleteActorCommandValidator>();
            services.AddScoped<IValidator<UpdateActorCommand>, UpdateActorCommandValidator>();
            services.AddScoped<IValidator<GetActorByIdQuery>, GetActorByIdQueryValidator>();

            services.AddScoped<IValidator<CreateMovieCommand>, CreateMovieCommandValidator>();
            services.AddScoped<IValidator<DeleteMovieCommand>, DeleteMovieCommandValidator>();
            services.AddScoped<IValidator<UpdateMovieCommand>, UpdateMovieCommandValidator>();
            services.AddScoped<IValidator<GetMovieByIdQuery>, GetMovieByIdQueryValidator>();


            return services;
        }
    }
}