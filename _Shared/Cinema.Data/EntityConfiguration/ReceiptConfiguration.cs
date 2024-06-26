﻿using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.EntityConfiguration
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("Receipt");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.TotalAmount).IsRequired();
            builder.Property(r => r.CreatedAt).IsRequired();

            builder.HasOne(r => r.ShoppingCart)
                .WithOne(sc => sc.Receipt)
                .HasForeignKey<ShoppingCart>(sc => sc.ReceiptId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(r => r.Tickets)
                .WithOne(t => t.Receipt)
                .HasForeignKey(t => t.ReceiptId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
