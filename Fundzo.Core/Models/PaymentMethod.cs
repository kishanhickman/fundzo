using System.ComponentModel.DataAnnotations;

namespace Fundzo.Core.Models
{
    /// <summary>
    /// Provides enumeration of different fundraiser types.
    /// </summary>
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        public string Method { get; set; }
        public bool? Enabled { get; set; }
        public ICollection<Payment>? Payments { get; set; }

    }
}
