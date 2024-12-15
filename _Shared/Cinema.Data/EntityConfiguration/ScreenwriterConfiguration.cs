using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class ScreenwriterConfiguration : IEntityTypeConfiguration<Screenwriter>
    {
        public void Configure(EntityTypeBuilder<Screenwriter> builder)
        {
            builder.ToTable("Screenwriter");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.FullName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Image).IsRequired();
            builder.Property(s => s.Biography).IsRequired().HasMaxLength(1000);
            builder.Property(s => s.Country).IsRequired().HasMaxLength(50);
            builder.Property(s => s.DateOfBirth).IsRequired();

            builder.HasMany(s => s.MovieScreenwriters)
                .WithOne(ms => ms.Screenwriter)
                .HasForeignKey(ms => ms.ScreenwriterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
