using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class UserProductPromoCodeConfiguration : IEntityTypeConfiguration<UserProductPromoCode>
    {
        public void Configure(EntityTypeBuilder<UserProductPromoCode> builder)
        {
            builder.ToTable("UserProductPromoCode");

            builder.HasKey(uppc => new { uppc.UserId, uppc.ProductPromoCodeId });

            builder.HasOne(uppc => uppc.User)
                .WithMany(m => m.UserProductPromoCodes)
                .HasForeignKey(uppc => uppc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(uppc => uppc.ProductPromoCode)
                .WithMany(p => p.UserProductPromoCodes)
                .HasForeignKey(uppc => uppc.ProductPromoCodeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
