using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticket");

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Session)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.SessionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Receipt)
                .WithMany(r => r.Tickets)
                .HasForeignKey(t => t.ReceiptId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.ShoppingCartItems)
                .WithOne(sci => sci.Ticket)
                .HasForeignKey(sci => sci.TicketId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}