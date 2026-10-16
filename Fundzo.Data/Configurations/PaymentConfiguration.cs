using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fundzo.Core.Models;

namespace Fundzo.Data.Configurations
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.CurrencyCode)
                .HasMaxLength(4);

            builder
                .HasOne(m => m.Donation)
                .WithMany(b => b.Payments)
                .HasForeignKey(m => m.DonationId);

            builder
                .HasOne(m => m.PaymentMethod)
                .WithMany(b => b.Payments)
                .HasForeignKey(m => m.PaymentMethodId);

            builder
                .HasOne(m => m.PaymentStatus)
                .WithMany(b => b.Payments)
                .HasForeignKey(m => m.PaymentStatusId);

            builder
                .ToTable("Payment");
        }
    }
}
