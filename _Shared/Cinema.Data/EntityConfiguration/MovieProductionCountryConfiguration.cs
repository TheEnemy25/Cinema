using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class MovieProductionCountryConfiguration : IEntityTypeConfiguration<MovieProductionCountry>
    {
        public void Configure(EntityTypeBuilder<MovieProductionCountry> builder)
        {
            builder.ToTable("MovieProductionCountry");

            builder.HasKey(mpc => new { mpc.MovieId, mpc.ProductionCountryId });

            builder.HasOne(mpc => mpc.Movie)
                .WithMany(m => m.MovieProductionCountries)
                .HasForeignKey(mpc => mpc.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(mpc => mpc.ProductionCountry)
                .WithMany(pc => pc.MovieProductionCountries)
                .HasForeignKey(mpc => mpc.ProductionCountryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}