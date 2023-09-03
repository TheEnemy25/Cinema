using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class MoviePromoCodeConfiguration : IEntityTypeConfiguration<MoviePromoCode>
    {
        public void Configure(EntityTypeBuilder<MoviePromoCode> builder)
        {
            builder.ToTable("MoviePromoCode");

            builder.HasKey(mpc => mpc.Id);

            builder.HasOne(mpc => mpc.Movie)
                .WithMany(m => m.MoviePromoCodes)
                .HasForeignKey(mpc => mpc.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(mpc => mpc.PromoCodeUsages)
                .WithOne(pcu => pcu.MoviePromoCode)
                .HasForeignKey(pcu => pcu.MoviePromoCodeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
