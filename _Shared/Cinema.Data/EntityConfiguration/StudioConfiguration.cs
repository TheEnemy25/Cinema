using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class StudioConfiguration : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder.ToTable("Studio");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Description).IsRequired().HasMaxLength(1000);
            builder.Property(s => s.Image).IsRequired();

            builder.HasMany(s => s.MovieStudios)
                .WithOne(ms => ms.Studio)
                .HasForeignKey(s => s.StudioId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}