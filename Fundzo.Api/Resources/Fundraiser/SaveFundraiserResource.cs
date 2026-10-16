namespace Fundzo.Api.Resources
{
    public class SaveFundraiserResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double? GoalAmount { get; set; }
        public int FundraiserTypeId { get; set; }
        public int CategoryId { get; set; }
        public int OrganisationId { get; set; }
        public int FundraiserStatusId { get; set; }
        public int CurrencyId { get; set; }
        public Guid UserId { get; set; }
    }
}