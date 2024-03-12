using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired();

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