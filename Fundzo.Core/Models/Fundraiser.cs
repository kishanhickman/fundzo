using System.ComponentModel.DataAnnotations;
using Fundzo.Core.Models;

namespace Fundzo.Core.Models
{
    public class Fundraiser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? GoalAmount { get; set; }
        public int? FundraiserTypeId { get; set; }
        public int? CategoryId { get; set; }
        public int? StatusId { get; set; }
        public Guid UserId { get; set; }
        public int? OrganisationId { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public FundraiserType? Type { get; set; }
        public Category? Category { get; set; }
        public FundraiserStatus? Status { get; set; }
        public Organisation? Organisation { get; set; }
        public Currency? Currency { get; set; }
        public ICollection<Donation>? Donations { get; set; }
        public ICollection<FundraiserMedia> FundraiserMedias { get; set; } 
    }
}
