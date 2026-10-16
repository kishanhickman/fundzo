using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fundzo.Core.Models;

namespace Fundzo.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .HasMaxLength(100);

            builder
                .Property(m => m.ShortCode)
                .HasMaxLength(4);

            builder
                .Property(m => m.CountryCode)
                .HasMaxLength(4);

            builder
                .ToTable("Country");
        }
    }
}
