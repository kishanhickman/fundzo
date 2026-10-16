namespace Fundzo.Api.Resources
{
    public class SaveDonationResource
    {
        public double Amount { get; set; }
        public int FundraiserId { get; set; }
        public Guid UserId { get; set; }
        public int CurrencyId { get; set; }
        public int StatusId { get; set; }
    }
}