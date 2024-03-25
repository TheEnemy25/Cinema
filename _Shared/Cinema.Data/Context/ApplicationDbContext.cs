using Cinema.Data.EntityConfiguration;
using Cinema.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<CinemaTheater> CinemaTheaters { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieProducer> MovieProducers { get; set; }
        public DbSet<MovieProductionCountry> MovieProductionCountris { get; set; }
        public DbSet<MovieScreenwriter> MovieScreenwriters { get; set; }
        public DbSet<MovieStudio> MovieStudios { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductionCountry> ProductionCountries { get; set; }
        public DbSet<ProductPromoCode> ProductPromoCodes { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Screenwriter> Screenwriters { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionPromoCode> SessionPromoCode { get; set; }
        public DbSet<SessionSeat> SessionSeats { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserProductPromoCode> UserProductPromoCodes { get; set; }
        public DbSet<UserSessionPromoCode> UserSessionPromoCodes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new CinemaTheaterConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new HallConfiguration());
            modelBuilder.ApplyConfiguration(new MovieActorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new MovieDirectorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieProducerConfiguration());
            modelBuilder.ApplyConfiguration(new MovieProductionCountryConfiguration());
            modelBuilder.ApplyConfiguration(new MovieScreenwriterConfiguration());
            modelBuilder.ApplyConfiguration(new MovieStudioConfiguration());
            modelBuilder.ApplyConfiguration(new ProducerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductionCountryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPromoCodeConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new RentalConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ScreenwriterConfiguration());
            modelBuilder.ApplyConfiguration(new SeatConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new SessionPromoCodeConfiguration());
            modelBuilder.ApplyConfiguration(new SessionSeatConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartItemConfiguration());
            modelBuilder.ApplyConfiguration(new StudioConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new UserProductPromoCodeConfiguration());
            modelBuilder.ApplyConfiguration(new UserSessionPromoCodeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}