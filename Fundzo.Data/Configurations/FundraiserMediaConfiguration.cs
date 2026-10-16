using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fundzo.Core.Models;

namespace Fundzo.Data.Configurations
{
    internal class FundraiserMediaConfiguration : IEntityTypeConfiguration<FundraiserMedia>
    {
        public void Configure(EntityTypeBuilder<FundraiserMedia> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .HasOne(a => a.Fundraiser)
                .WithMany(m => m.FundraiserMedias)
                .HasForeignKey(a => a.FundraiserId);

            builder
                .HasOne(a => a.StaticMedia)
                .WithMany(m => m.FundraiserMedias)
                .HasForeignKey(a => a.StaticMediaId);

            builder
                .ToTable("FundraiserMedia");
        }
    }
}
