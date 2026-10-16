namespace Fundzo.Api.Resources
{
    public class DonationResource
    {
        public int Id { get; set; }
        public string? ReferenceNumber { get; set; }
        public double Amount { get; set; }
        public double AmountFR { get; set; }
        public FundraiserResource Fundraiser { get; set; }
        public int? User { get; set; }
        public CurrencyResource Currency { get; set; }
        public DonationStatusResource Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}