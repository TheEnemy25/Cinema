using Cinema.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity => entity.ToTable(name: "Users"));
            builder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
            builder.Entity<IdentityUserRole<string>>(entity => entity.ToTable(name: "UserRoles"));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable(name: "UserClaim"));  
            builder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable(name: "UserLogins"));
            builder.Entity<IdentityUserToken<string>>(entity => entity.ToTable(name: "UserTokens"));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable(name: "UserClaims"));

            builder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Genre> Categories{ get; set; }
        public DbSet<Entities.Cinema> Cinemas { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CinemaHall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        
    }
}
