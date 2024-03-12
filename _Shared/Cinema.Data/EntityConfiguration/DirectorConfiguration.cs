using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Director");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();

            builder.Property(d => d.FullName).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Image).IsRequired();
            builder.Property(d => d.Biography).IsRequired();
            builder.Property(d => d.Country).IsRequired().HasMaxLength(50);
            builder.Property(d => d.DateOfBirth).IsRequired().HasMaxLength(50);

            builder.HasMany(d => d.MovieDirectors)
               .WithOne(md => md.Director)
               .HasForeignKey(md => md.DirectorId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
