using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class SessionSeatConfiguration : IEntityTypeConfiguration<SessionSeat>
    {
        public void Configure(EntityTypeBuilder<SessionSeat> builder)
        {
            builder.HasKey(ss => new { ss.SessionId, ss.SeatId });

            builder.HasOne(ss => ss.Session)
                .WithMany(m => m.SessionSeats)
                .HasForeignKey(ss => ss.SessionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ss => ss.Seat)
                .WithMany(s => s.SessionSeats)
                .HasForeignKey(ss => ss.SeatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
