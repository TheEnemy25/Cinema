using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.ToTable("Producer");

            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.MovieProducers)
                .WithOne(mp => mp.Producer)
                .HasForeignKey(mp => mp.ProducerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}