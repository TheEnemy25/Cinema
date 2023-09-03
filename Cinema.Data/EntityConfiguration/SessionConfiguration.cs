using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Session");

            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Hall)
                .WithMany(h => h.Sessions)
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Movie)
                .WithMany(m => m.Sessions)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Discount)
                .WithMany(d => d.Sessions)
                .HasForeignKey(s => s.DiscountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.SessionSeats)
                .WithOne(ss => ss.Session)
                .HasForeignKey(ss => ss.SessionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Tickets)
                .WithOne(t => t.Session)
                .HasForeignKey(s => s.SessionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
