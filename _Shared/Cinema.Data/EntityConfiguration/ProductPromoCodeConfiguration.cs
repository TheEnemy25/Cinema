using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class ProductPromoCodeConfiguration : IEntityTypeConfiguration<ProductPromoCode>
    {
        public void Configure(EntityTypeBuilder<ProductPromoCode> builder)
        {
            builder.ToTable("ProductPromoCode");

            builder.HasKey(ppc => ppc.Id);
            builder.Property(ppc => ppc.Id).ValueGeneratedOnAdd();

            builder.Property(ppc => ppc.PromoCode).IsRequired().HasMaxLength(50);
            builder.Property(ppc => ppc.DiscountPercentage).IsRequired();
            builder.Property(ppc => ppc.MaxUsageCount).IsRequired();

            builder.HasOne(ppc => ppc.Product)
                .WithMany(p => p.ProductPromoCodes)
                .HasForeignKey(ppc => ppc.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(ppc => ppc.UserProductPromoCodes)
                .WithOne(uppc => uppc.ProductPromoCode)
                .HasForeignKey(uppc => uppc.ProductPromoCodeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}





