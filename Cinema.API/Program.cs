using Cinema.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Cinema", Version = "v1" });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors(options =>
{
    // Add your CORS policy configuration here
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema v1"));
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();




//using Cinema.API;
//using Cinema.Data.Context;
//using Cinema.Data.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "Cinema", Version = "v1" });
//});

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(connectionString);
//});

//builder.Services.AddIdentity<User, IdentityRole>(config =>
//{
//    config.Password.RequiredLength = 8;
//    config.Password.RequireDigit = true;
//    config.Password.RequireNonAlphanumeric = false;
//    config.Password.RequireUppercase = false;
//})
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddIdentityServer()
//    .AddAspNetIdentity<User>()
//    .AddInMemoryApiResources(Configuration.ApiResources)
//    .AddInMemoryIdentityResources(Configuration.IdentityResources)
//    .AddInMemoryApiScopes(Configuration.ApiScopes)
//    .AddInMemoryClients(Configuration.Clients)
//    .AddDeveloperSigningCredential();

//builder.Services.ConfigureApplicationCookie(config =>
//{
//    config.Cookie.Name = "Cinema.Identity.Cookie";
//    config.LoginPath = "/Auth/Login";
//    config.LogoutPath = "/Auth/Logout";
//});

//var provider = builder.Services.BuildServiceProvider();
//var configuration = provider.GetRequiredService<IConfiguration>();

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddCors(options =>
//{
//    var frontendURL = configuration.GetValue<string>("FrontendURL");

//    options.AddDefaultPolicy(builder =>
//    {
//        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
//    });
//});

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema v1"));
//}

//app.UseHttpsRedirection();

//app.UseCors();

//app.UseAuthorization();

//app.MapControllers();

//using (var scope = app.Services.CreateScope())
//{
//    var service = scope.ServiceProvider;
//    try
//    {
//        var context = service.GetRequiredService<ApplicationDbContext>();
//        DbInitializer.Initialize(context);
//    }
//    catch (Exception exception)
//    {
//        var logger = service.GetRequiredService<ILogger<Program>>();
//        logger.LogError(exception, "An error occurred while seeding the database.");
//    }
//}

//app.Run();
