using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.CinemaTheater)
                .WithMany(ct => ct.Employees)
                .HasForeignKey(e => e.CinemaTheaterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
