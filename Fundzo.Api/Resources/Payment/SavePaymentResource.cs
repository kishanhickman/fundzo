namespace Fundzo.Api.Resources.Payment
{
    public class SavePaymentResource
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }
        public int PaymentStatusId { get; set; }
        public int DonationId { get; set; }
        public int CurrencyId { get; set; }
    }
}
