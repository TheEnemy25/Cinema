using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discount");

            builder.HasKey(d => d.Id);

            builder.HasMany(d => d.Sessions)
                .WithOne(s => s.Discount)
                .HasForeignKey(s => s.DiscountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(d => d.Products)
                .WithOne(p => p.Discount)
                .HasForeignKey(p => p.DiscountId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
