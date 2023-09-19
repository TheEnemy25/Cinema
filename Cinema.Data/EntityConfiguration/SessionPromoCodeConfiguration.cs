﻿using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data.EntityConfiguration
{
    public class SessionPromoCodeConfiguration : IEntityTypeConfiguration<SessionPromoCode>
    {
        public void Configure(EntityTypeBuilder<SessionPromoCode> builder)
        {
            builder.ToTable("SessionPromoCode");

            builder.HasKey(spc => spc.Id);

            builder.HasOne(spc => spc.Session)
               .WithMany(s => s.SessionPromoCodes)
               .HasForeignKey(spc => spc.SessionId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(spc => spc.PromoCodeUsages)
                .WithOne(pcu => pcu.SessionPromoCode)
                .HasForeignKey(pcu => pcu.SessionPromoCodeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}