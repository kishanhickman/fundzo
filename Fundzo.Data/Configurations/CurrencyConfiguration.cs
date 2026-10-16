using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fundzo.Core.Models;

namespace Fundzo.Data.Configurations
{
    internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
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
                .Property(m => m.Code)
                .HasMaxLength(4);

            builder
                .Property(m => m.Symbol)
                .HasMaxLength(3);

            builder
                .ToTable("Currency");
        }
    }
}
