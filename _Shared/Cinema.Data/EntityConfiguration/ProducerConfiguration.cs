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
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.FullName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.Biography).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.Country).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DateOfBirth).IsRequired();

            builder.HasMany(p => p.MovieProducers)
                .WithOne(mp => mp.Producer)
                .HasForeignKey(mp => mp.ProducerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}