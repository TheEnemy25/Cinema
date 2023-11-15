using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class MovieProducerConfiguration : IEntityTypeConfiguration<MovieProducer>
    {
        public void Configure(EntityTypeBuilder<MovieProducer> builder)
        {
            builder.ToTable("MovieProducer");

            builder.HasKey(mp => new { mp.MovieId, mp.ProducerId });

            builder.HasOne(mp => mp.Movie)
                .WithMany(m => m.MovieProducers)
                .HasForeignKey(mp => mp.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(mp => mp.Producer)
                .WithMany(p => p.MovieProducers)
                .HasForeignKey(mp => mp.ProducerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}