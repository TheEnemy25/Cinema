using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class ScreenwriterConfiguration : IEntityTypeConfiguration<Screenwriter>
    {
        public void Configure(EntityTypeBuilder<Screenwriter> builder)
        {
            builder.ToTable("Screenwriter");

            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.MovieScreenwriters)
                .WithOne(ms => ms.Screenwriter)
                .HasForeignKey(ms => ms.ScreenwriterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
