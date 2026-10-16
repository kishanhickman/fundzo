using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fundzo.Core.Models;

namespace Fundzo.Data.Configurations
{
    internal class DonationStatusConfiguration : IEntityTypeConfiguration<DonationStatus>
    {
        public void Configure(EntityTypeBuilder<DonationStatus> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Status)
                .HasMaxLength(100);

            builder
                .ToTable("DontationStatus");
        }
    }
}
