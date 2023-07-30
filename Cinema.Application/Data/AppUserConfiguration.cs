using Cinema.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Application.Data
{
    public class AppUserConfiguration
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
