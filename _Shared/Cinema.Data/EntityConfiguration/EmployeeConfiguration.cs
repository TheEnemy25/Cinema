using Cinema.Infrastructure.Entities;
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
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.PhoneNumber).IsRequired();
            builder.Property(e => e.DateOfBirth);
            builder.Property(e => e.Role).IsRequired();

            builder.HasOne(e => e.CinemaTheater)
                .WithMany(ct => ct.Employees)
                .HasForeignKey(e => e.CinemaTheaterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
