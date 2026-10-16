using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Data.Configurations;


namespace Fundzo.Data
{
    public partial class FundzoContext : DbContext
    {

        public FundzoContext(DbContextOptions<FundzoContext> options)
            : base(options)
        {
            // This method creates the database from the model schema (so not the migrations)
            // Database.EnsureCreated();
        }

        public DbSet<Address> Addressess { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<DonationStatus> DonationStatuses { get; set; }
        public DbSet<Fundraiser> Fundraisers { get; set; }
        public DbSet<FundraiserMedia> FundraiserMedias { get; set; }
        public DbSet<FundraiserStatus> FundraiserStatuses { get; set; }
        public DbSet<FundraiserType> FundraiserTypes { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<StaticMedia> StaticMedias { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .ApplyConfiguration(new AddressConfiguration());

            builder.Entity<Address>().ToTable("Address");
            builder.Entity<Category>().ToTable("Category");
            builder.Entity<Country>().ToTable("Country");
            builder.Entity<Currency>().ToTable("Currency");
            builder.Entity<Donation>().ToTable("Donation");
            builder.Entity<DonationStatus>().ToTable("DonationStatus");
            builder.Entity<Fundraiser>().ToTable("Fundraiser");
            builder.Entity<FundraiserMedia>().ToTable("FundraiserMedia");
            builder.Entity<FundraiserStatus>().ToTable("FundraiserStatus");
            builder.Entity<FundraiserType>().ToTable("FundraiserType");
            builder.Entity<Industry>().ToTable("Industry");
            builder.Entity<Organisation>().ToTable("Organisation");
            builder.Entity<Payment>().ToTable("Payment");
            builder.Entity<PaymentMethod>().ToTable("PaymentMethod");
            builder.Entity<PaymentStatus>().ToTable("PaymentStatus");
            builder.Entity<StaticMedia>().ToTable("StaticMedia");
        }

    }
}
