using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fundzo.Core.Models;

namespace Fundzo.Data.Configurations
{
    internal class FundraiserTypeConfiguration : IEntityTypeConfiguration<FundraiserType>
    {
        public void Configure(EntityTypeBuilder<FundraiserType> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Type)
                .HasMaxLength(100);

            builder
                .ToTable("FundraiserType");
        }
    }
}
