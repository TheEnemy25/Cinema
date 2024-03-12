using Cinema.Infrastructure.Entities;
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
            builder.Property(h => h.Id).ValueGeneratedOnAdd();

            builder.Property(h => h.Number).IsRequired();
            builder.Property(h => h.Rows).IsRequired();
            builder.Property(h => h.SeatsPerRow).IsRequired();
            builder.Property(h => h.NormalSeatsCount).IsRequired();
            builder.Property(h => h.VIPSeatsCount).IsRequired();
            builder.Property(h => h.HallType).IsRequired();
            builder.Property(h => h.Status);
            builder.Property(h => h.BasePrice).IsRequired().HasMaxLength(50);
            builder.Property(h => h.VIPPrice).IsRequired();

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
