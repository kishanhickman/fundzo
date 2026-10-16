using Fundzo.Api.Resources.Admin.Industries;

namespace Fundzo.Api.Resources
{
    public class OrganisationResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string CompanyNumber { get; set; }
        public string? VATNumber { get; set; }
        public AddressResource? Address { get; set; }
        public IndustryResource? Industry { get; set; }
    }
}