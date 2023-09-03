using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCart");

            builder.HasKey(sc => sc.Id);

            builder.HasOne(sc => sc.Receipt)
                .WithOne(r => r.ShoppingCart)
                .HasForeignKey<Receipt>(r => r.ShoppingCartId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(sc => sc.ShoppingCartItems)
                .WithOne(sci => sci.ShoppingCart)
                .HasForeignKey(sci => sci.ShoppingCartId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}