using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");

            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).ValueGeneratedOnAdd();

            builder.Property(g => g.Name).IsRequired().HasMaxLength(50);
            builder.Property(g => g.Description).IsRequired().HasMaxLength(100);
            builder.Property(g => g.ImageURL).IsRequired();

            builder.HasMany(g => g.MovieGenres)
                .WithOne(mg => mg.Genre)
                .HasForeignKey(mg => mg.GenreId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
