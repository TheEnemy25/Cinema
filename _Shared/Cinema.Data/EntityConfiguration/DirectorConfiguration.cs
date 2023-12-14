using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Director");

            builder.HasKey(d => d.Id);

            builder.HasMany(d => d.MovieDirectors)
               .WithOne(md => md.Director)
               .HasForeignKey(md => md.DirectorId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
