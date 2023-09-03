using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");

            builder.HasKey(m => m.Id);

            builder.HasMany(m => m.MovieDirectors)
                .WithOne(md => md.Movie)
                .HasForeignKey(md => md.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.MovieActors)
                .WithOne(ma => ma.Movie)
                .HasForeignKey(ma => ma.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.MovieGenres)
                .WithOne(mg => mg.Movie)
                .HasForeignKey(mg => mg.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.MovieProducers)
                .WithOne(mp => mp.Movie)
                .HasForeignKey(mp => mp.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.MovieScreenwriters)
                .WithOne(ms => ms.Movie)
                .HasForeignKey(ms => ms.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.MovieStudios)
                .WithOne(ms => ms.Movie)
                .HasForeignKey(ms => ms.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.MoviePromoCodes)
                .WithOne(mpc => mpc.Movie)
                .HasForeignKey(mpc => mpc.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.Reviews)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.Sessions)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.Rentals)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.MovieProductionCountries)
                .WithOne(mpc => mpc.Movie)
                .HasForeignKey(mpc => mpc.MovieId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
