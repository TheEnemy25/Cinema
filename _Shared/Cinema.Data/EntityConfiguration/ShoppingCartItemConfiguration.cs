using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration;
public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
    {
        builder.ToTable("ShoppingCartItem");

        builder.HasKey(sci => sci.Id);

        builder.HasOne(sci => sci.ShoppingCart)
            .WithMany(sc => sc.ShoppingCartItems)
            .HasForeignKey(sci => sci.ShoppingCartId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(sci => sci.Ticket)
            .WithMany(t => t.ShoppingCartItems)
            .HasForeignKey(sci => sci.TicketId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(sci => sci.Product)
            .WithMany(p => p.ShoppingCartItems)
            .HasForeignKey(sci => sci.ProductId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}