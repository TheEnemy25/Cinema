using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUser");

            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.ShoppingCarts)
                .WithOne(sc => sc.User)
                .HasForeignKey(sc => sc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.UserProductPromoCodes)
                .WithOne(uppc => uppc.User)
                .HasForeignKey(uppc => uppc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.UserSessionPromoCodes)
                .WithOne(uspc => uspc.User)
                .HasForeignKey(uspc => uspc.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
