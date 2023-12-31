﻿using Cinema.Data.Context;
using Cinema.Domain.Services.Implementation;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Domain
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<ICinemaTheaterService, CinemaTheaterService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IHallService, HallService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IProducerService, ProducerService>();
            services.AddScoped<IProductPromoCodeService, ProductPromoCodeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IScreenwriterService, ScreenwriterService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<ISessionPromoCodeService, SessionPromoCodeService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IShoppingCartItemService, ShoppingCartItemService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IStudioService, StudioService>();
            services.AddScoped<ITicketService, TicketService>();

            services.AddIdentity<AppUser, AppRole>(config =>
            {
                config.Password.RequiredLength = 8;
                config.Password.RequireDigit = true;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddSignInManager<SignInManager<AppUser>>();

            return services;
        }
    }
}