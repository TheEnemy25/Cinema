using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class PromoCodeUsageConfiguration : IEntityTypeConfiguration<PromoCodeUsage>
    {
        public void Configure(EntityTypeBuilder<PromoCodeUsage> builder)
        {
            builder.ToTable("PromoCodeUsage");

            builder.HasKey(pcu => pcu.Id);

            builder.HasOne(pcu => pcu.MoviePromoCode)
                .WithMany(mpc => mpc.PromoCodeUsages)
                .HasForeignKey(pcu => pcu.MoviePromoCodeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pcu => pcu.ProductPromoCode)
                .WithMany(ppc => ppc.PromoCodeUsages)
                .HasForeignKey(pcu => pcu.ProductPromoCodeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}






