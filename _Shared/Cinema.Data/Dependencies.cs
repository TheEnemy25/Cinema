﻿using Cinema.Data.Context;
using Cinema.Data.Infrastructure;
using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Data
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Actor>, BaseRepository<Actor>>();
            services.AddScoped<IBaseRepository<CinemaTheater>, BaseRepository<CinemaTheater>>();
            services.AddScoped<IBaseRepository<City>, BaseRepository<City>>();
            services.AddScoped<IBaseRepository<Country>, BaseRepository<Country>>();
            services.AddScoped<IBaseRepository<Director>, BaseRepository<Director>>();
            services.AddScoped<IBaseRepository<Discount>, BaseRepository<Discount>>();
            services.AddScoped<IBaseRepository<Employee>, BaseRepository<Employee>>();
            services.AddScoped<IBaseRepository<Genre>, BaseRepository<Genre>>();
            services.AddScoped<IBaseRepository<Hall>, BaseRepository<Hall>>();
            services.AddScoped<IBaseRepository<Movie>, BaseRepository<Movie>>();
            services.AddScoped<IBaseRepository<Producer>, BaseRepository<Producer>>();
            services.AddScoped<IBaseRepository<Product>, BaseRepository<Product>>();
            services.AddScoped<IBaseRepository<ProductionCountry>, BaseRepository<ProductionCountry>>();
            services.AddScoped<IBaseRepository<ProductPromoCode>, BaseRepository<ProductPromoCode>>();
            services.AddScoped<IBaseRepository<Receipt>, BaseRepository<Receipt>>();
            services.AddScoped<IBaseRepository<Rental>, BaseRepository<Rental>>();
            services.AddScoped<IBaseRepository<Review>, BaseRepository<Review>>();
            services.AddScoped<IBaseRepository<Screenwriter>, BaseRepository<Screenwriter>>();
            services.AddScoped<IBaseRepository<Seat>, BaseRepository<Seat>>();
            services.AddScoped<IBaseRepository<Session>, BaseRepository<Session>>();
            services.AddScoped<IBaseRepository<SessionPromoCode>, BaseRepository<SessionPromoCode>>();
            services.AddScoped<IBaseRepository<SessionSeat>, BaseRepository<SessionSeat>>();
            services.AddScoped<IBaseRepository<ShoppingCart>, BaseRepository<ShoppingCart>>();
            services.AddScoped<IBaseRepository<ShoppingCartItem>, BaseRepository<ShoppingCartItem>>();
            services.AddScoped<IBaseRepository<Studio>, BaseRepository<Studio>>();
            services.AddScoped<IBaseRepository<Ticket>, BaseRepository<Ticket>>();

            return services;
        }

        public static IServiceCollection RegisterContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CinemaDb")));

            return services;
        }
    }
}