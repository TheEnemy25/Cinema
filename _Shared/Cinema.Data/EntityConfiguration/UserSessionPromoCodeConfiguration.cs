using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class UserSessionPromoCodeConfiguration : IEntityTypeConfiguration<UserSessionPromoCode>
    {
        public void Configure(EntityTypeBuilder<UserSessionPromoCode> builder)
        {
            builder.ToTable("UserSessionPromoCode");

            builder.HasKey(uspc => new { uspc.UserId, uspc.SessionPromoCodeId });

            builder.Property(uspc => uspc.UsageDate).IsRequired();

            builder.HasOne(uspc => uspc.User)
                .WithMany(m => m.UserSessionPromoCodes)
                .HasForeignKey(uspc => uspc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(uspc => uspc.SessionPromoCode)
                .WithMany(p => p.UserSessionPromoCodes)
                .HasForeignKey(uspc => uspc.SessionPromoCodeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
