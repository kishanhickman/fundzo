using Fundzo.Api.Resources.Fundraiser;

namespace Fundzo.Api.Resources
{
    public class FundraiserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double GoalAmount { get; set; }
        public FundraiserTypeResource Type { get; set; }
        public CategoryResource Category { get; set; }
        public FundraiserStatusResource Status { get; set; }
        public Guid? User { get; set; }
        public OrganisationResource Organisation { get; set; }
        public CurrencyResource Currency { get; set; }
        public FundraiserMediaResource? FundraiserMedia { get; set; }
        public DateTime DateCreated { get; set; }
       
    }
}