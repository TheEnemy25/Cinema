using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class UserProductPromoCodeConfiguration : IEntityTypeConfiguration<UserProductPromoCode>
    {
        public void Configure(EntityTypeBuilder<UserProductPromoCode> builder)
        {
            builder.ToTable("UserProductPromoCode");

            builder.HasKey(uppc => uppc.Id);
            builder.Property(uppc => uppc.Id).ValueGeneratedOnAdd();

            builder.Property(uppc => uppc.UsageDate).IsRequired();

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
