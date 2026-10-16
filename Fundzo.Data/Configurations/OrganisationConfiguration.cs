using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fundzo.Core.Models;

namespace Fundzo.Data.Configurations
{
    internal class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .HasMaxLength(100);

            builder
                .Property(m => m.VATNumber)
                .HasMaxLength(20);

            builder
                .HasOne(m => m.Address)
                .WithOne(b => b.Organisation)
                .HasForeignKey<Organisation>(m => m.AddressId);

            builder
                .HasOne(m => m.Industry)
                .WithOne(b => b.Organisation)
                .HasForeignKey<Organisation>(m => m.IndustryId);

            builder
                .ToTable("Organisation");
        }
    }
}
