using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fundzo.Core.Models;

namespace Fundzo.Data.Configurations
{
    internal class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.ReferenceNumber)
                .HasMaxLength(20);

            builder
                .HasOne(m => m.Fundraiser)
                .WithMany(a => a.Donations)
                .HasForeignKey(m => m.FundraiserId);

            builder
                .HasOne(m => m.Currency)
                .WithMany(a => a.Donations)
                .HasForeignKey(m => m.CurrencyId);

            builder
                .HasOne(m => m.Status)
                .WithMany(a => a.Donations)
                .HasForeignKey(m => m.StatusId);

            builder
                .ToTable("Donation");
        }
    }
}