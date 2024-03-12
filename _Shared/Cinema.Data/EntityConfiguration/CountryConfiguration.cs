using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");

            builder.HasKey(co => co.Id);
            builder.Property(co => co.Id).ValueGeneratedOnAdd();

            builder.Property(co => co.Name).IsRequired().HasMaxLength(50);
            builder.Property(co => co.CountryCode).IsRequired().HasMaxLength(50);

            builder.HasMany(co => co.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
