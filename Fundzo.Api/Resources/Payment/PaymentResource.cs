namespace Fundzo.Api.Resources
{
    public class PaymentResource
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DonationResource? Donation { get; set; }
        public PaymentMethodResource? PaymentMethod { get; set; }
        public PaymentStatusResource? PaymentStatus { get; set; }
        public DateTime DateCreated { get; set; }
    }
}