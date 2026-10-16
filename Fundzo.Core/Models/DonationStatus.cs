using System.ComponentModel.DataAnnotations;

namespace Fundzo.Core.Models
{
    public class DonationStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
        public ICollection<Donation>? Donations { get; set; }
    }

}