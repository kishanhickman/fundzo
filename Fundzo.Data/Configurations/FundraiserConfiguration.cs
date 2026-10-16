using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fundzo.Core.Models;

namespace Fundzo.Data.Configurations
{
    internal class FundraiserConfiguration : IEntityTypeConfiguration<Fundraiser>
    {
        public void Configure(EntityTypeBuilder<Fundraiser> builder)
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
                .HasOne(m => m.Type)
                .WithMany(a => a.Fundraisers)
                .HasForeignKey(m => m.FundraiserTypeId);

            builder
                .HasOne(m => m.Category)
                .WithMany(a => a.Fundraisers)
                .HasForeignKey(m => m.CategoryId);

            builder
               .HasOne(m => m.Status)
               .WithMany(a => a.Fundraisers)
               .HasForeignKey(m => m.StatusId);

            builder
                .HasOne(m => m.Organisation)
                .WithMany(a => a.Fundraisers)
                .HasForeignKey(m => m.OrganisationId);

            builder
                .HasOne(m => m.Currency)
                .WithMany(a => a.Fundraisers)
                .HasForeignKey(m => m.CurrencyId);

            builder
                .ToTable("Fundraiser");
        }
    }
}
