using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seat");

            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Hall)
                .WithMany(h => h.Seats)
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.SessionSeats)
                .WithOne(ss => ss.Seat)
                .HasForeignKey(ss => ss.SeatId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.ShoppingCartItems)
                .WithOne(sci => sci.Seat)
                .HasForeignKey(sci => sci.SeatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}