using System.ComponentModel.DataAnnotations;

namespace Fundzo.Core.Models
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
        public ICollection<Payment>? Payments { get; set; }

    }

}