using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.ToTable("Hall");

            builder.HasKey(h => h.Id);

            builder.HasOne(h => h.CinemaTheater)
                .WithMany(ct => ct.Halls)
                .HasForeignKey(h => h.CinemaTheaterId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(h => h.Seats)
                .WithOne(s => s.Hall)
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(h => h.Sessions)
                .WithOne(s => s.Hall)
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
