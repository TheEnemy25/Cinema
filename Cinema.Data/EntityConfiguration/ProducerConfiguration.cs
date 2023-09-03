using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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