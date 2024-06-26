﻿using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("Rental");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.RentalDate).IsRequired();

            builder.HasOne(r => r.Movie)
                .WithMany(m => m.Rentals)
                .HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.CinemaTheater)
               .WithMany(ct => ct.Rentals)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}