using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class MovieScreenwriterConfiguration : IEntityTypeConfiguration<MovieScreenwriter>
    {
        public void Configure(EntityTypeBuilder<MovieScreenwriter> builder)
        {
            builder.ToTable("MovieScreenwriter");

            builder.HasKey(ms => new { ms.MovieId, ms.ScreenwriterId });

            builder.HasOne(ms => ms.Movie)
                .WithMany(m => m.MovieScreenwriters)
                .HasForeignKey(ms => ms.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ms => ms.Screenwriter)
                .WithMany(s => s.MovieScreenwriters)
                .HasForeignKey(ms => ms.ScreenwriterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
