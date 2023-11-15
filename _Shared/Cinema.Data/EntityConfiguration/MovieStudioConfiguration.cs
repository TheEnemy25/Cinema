using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class MovieStudioConfiguration : IEntityTypeConfiguration<MovieStudio>
    {
        public void Configure(EntityTypeBuilder<MovieStudio> builder)
        {
            builder.ToTable("MovieStudio");

            builder.HasKey(ms => new { ms.MovieId, ms.StudioId });

            builder.HasOne(ms => ms.Movie)
                .WithMany(m => m.MovieStudios)
                .HasForeignKey(ms => ms.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ms => ms.Studio)
                .WithMany(s => s.MovieStudios)
                .HasForeignKey(ms => ms.StudioId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}