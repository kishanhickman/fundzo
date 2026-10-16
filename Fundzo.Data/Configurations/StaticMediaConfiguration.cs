using Fundzo.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fundzo.Data.Configurations
{
    public class StaticMediaConfiguration : IEntityTypeConfiguration<StaticMedia>
    {
        public void Configure(EntityTypeBuilder<StaticMedia> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .HasMaxLength(100);

            builder
                .Property(m => m.Extension)
                .HasMaxLength(100);

            builder
                .Property(m => m.BlobUrl)
                .HasMaxLength(100);

            builder
                .Property(m => m.Page)
                .HasMaxLength(100);

            builder
                .Property(m => m.Layout)
                .HasMaxLength(100);

            builder
                .ToTable("StaticMedia");
        }
    }
}
