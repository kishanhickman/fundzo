using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fundzo.Core.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public int? FundraiserId { get; set; }
        public Guid UserId { get; set; }
        public string? ReferenceNumber { get; set; }
        public int? StatusId { get; set; }
        public double Amount { get; set; }
        public int? CurrencyId { get; set; }
        public double? AmountFR { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public Fundraiser? Fundraiser { get; set; }
        public Currency? Currency { get; set; }
        public DonationStatus? Status { get; set; }
        public ICollection<Payment>? Payments { get; set; }

    }
}
