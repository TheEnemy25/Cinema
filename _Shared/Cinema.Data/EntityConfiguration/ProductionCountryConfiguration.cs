using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class ProductionCountryConfiguration : IEntityTypeConfiguration<ProductionCountry>
    {
        public void Configure(EntityTypeBuilder<ProductionCountry> builder)
        {
            builder.ToTable("ProductionCountry");

            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Id).ValueGeneratedOnAdd();

            builder.Property(pc => pc.CountryName).IsRequired();

            builder.HasMany(pc => pc.MovieProductionCountries)
                .WithOne(mpc => mpc.ProductionCountry)
                .HasForeignKey(mpc => mpc.ProductionCountryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}