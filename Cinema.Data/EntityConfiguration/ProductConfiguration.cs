using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Discount)
                .WithMany(d => d.Products)
                .HasForeignKey(p => p.DiscountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.ProductPromoCodes)
                .WithOne(ppc => ppc.Product)
                .HasForeignKey(ppc => ppc.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.ShoppingCartItems)
                .WithOne(sci => sci.Product)
                .HasForeignKey(sci => sci.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}