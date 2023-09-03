using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("Rental");

            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Movie)
                .WithMany(m => m.Rentals)
                .HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.CinemaTheater)
               .WithMany(ct => ct.Rentals)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}