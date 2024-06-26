﻿using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class SessionSeatConfiguration : IEntityTypeConfiguration<SessionSeat>
    {
        public void Configure(EntityTypeBuilder<SessionSeat> builder)
        {
            builder.HasKey(ss => ss.Id);
            builder.Property(ss => ss.Id).ValueGeneratedOnAdd();

            builder.Property(ss => ss.Status).IsRequired();

            builder.HasOne(ss => ss.Session)
                .WithMany(m => m.SessionSeats)
                .HasForeignKey(ss => ss.SessionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ss => ss.Seat)
                .WithMany(s => s.SessionSeats)
                .HasForeignKey(ss => ss.SeatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
