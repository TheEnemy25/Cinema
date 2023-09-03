using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class CinemaTheaterConfiguration : IEntityTypeConfiguration<CinemaTheater>
    {
        public void Configure(EntityTypeBuilder<CinemaTheater> builder)
        {
            builder.ToTable("CinemaTheater");

            builder.HasKey(ct => ct.Id);

            builder.HasMany(ct => ct.Halls)
                .WithOne(h => h.CinemaTheater)
                .HasForeignKey(h => h.CinemaTheaterId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(ct => ct.Employees)
                .WithOne(e => e.CinemaTheater)
                .HasForeignKey(e => e.CinemaTheaterId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ct => ct.City)
                .WithMany(c => c.CinemaTheaters)
                .HasForeignKey(ct => ct.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ct => ct.Rental) 
               .WithOne(r => r.CinemaTheater)
               .HasForeignKey<Rental>(r => r.CinemaTheaterId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
