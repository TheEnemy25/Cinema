using Cinema.Data.Entities;
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

            builder.HasMany(s => s.MovieScreenwriters)
                .WithOne(ms => ms.Screenwriter)
                .HasForeignKey(ms => ms.ScreenwriterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
