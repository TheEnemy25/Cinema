using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable("Actor");

            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.MovieActors)
                .WithOne(ma => ma.Actor)
                .HasForeignKey(ma => ma.ActorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
