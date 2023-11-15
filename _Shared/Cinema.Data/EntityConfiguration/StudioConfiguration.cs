using Cinema.Data.Entities;
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

            builder.HasMany(s => s.MovieStudios)
                .WithOne(ms => ms.Studio)
                .HasForeignKey(s => s.StudioId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}