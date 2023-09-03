using Cinema.Data.Entities;
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

            builder.HasOne(ppc => ppc.Product)
                .WithMany(p => p.ProductPromoCodes)
                .HasForeignKey(ppc => ppc.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(ppc => ppc.PromoCodeUsages)
                .WithOne(pcu => pcu.ProductPromoCode)
                .HasForeignKey(pcu => pcu.ProductPromoCodeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}





