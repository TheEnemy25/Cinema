using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable("Actor");

            // TODO: Complete all entity configurations
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.FullName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Image).IsRequired();
            builder.Property(a => a.Biography).IsRequired();
            builder.Property(a => a.Country).IsRequired().HasMaxLength(50);
            builder.Property(a => a.DateOfBirth).IsRequired();

            builder.HasMany(a => a.MovieActors)
                .WithOne(ma => ma.Actor)
                .HasForeignKey(ma => ma.ActorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
