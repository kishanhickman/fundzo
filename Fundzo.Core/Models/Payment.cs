using System.ComponentModel.DataAnnotations;

namespace Fundzo.Core.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int? DonationId { get; set; }
        public Guid UserId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? PaymentStatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public Donation? Donation { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }

    }
}
