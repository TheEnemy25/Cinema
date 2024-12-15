using Cinema.Application;
using Cinema.Domain;
using Cinema.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Cinema.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Cinema", Version = "v1" });
    c.MapType<TimeSpan>(() => new OpenApiSchema
    {
        Type = typeof(string).Name,
        Example = new OpenApiString("00:00:00")
    });
});


builder.Services.RegisterContext(builder.Configuration)
    .RegisterRepositories()
    .RegisterAutoMapper()
    .RegisterServices()
    .RegisterMediatRAndHanlders()
    .RegisterValidators();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5443/";
                    options.Audience = "CinemaWebAPI";
                    options.RequireHttpsMetadata = false;
                });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema v1"));
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();