using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fundzo.Core.Models;

namespace Fundzo.Data.Configurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.AddressLine1)
                .HasMaxLength(500);

            builder
                .Property(m => m.AddressLine2)
                .HasMaxLength(500);

            builder
                .Property(m => m.City)
                .HasMaxLength(100);

            builder
                .Property(m => m.State)
                .HasMaxLength(100);

            builder
                .Property(m => m.PostCode)
                .HasMaxLength(10);

            builder
                .HasOne(m => m.Country)
                .WithOne(b => b.Address)
                .HasForeignKey<Address>(m => m.CountryId);

            builder
                .ToTable("Address");
        }
    }
}
