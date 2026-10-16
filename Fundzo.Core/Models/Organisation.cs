using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fundzo.Core.Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? IndustryId { get; set; }
        public int? AddressId { get; set; }
        public string CompanyNumber { get; set; }
        public string? VATNumber { get; set; }
        public Address? Address { get; set; }
        public Industry? Industry { get; set; }
        [JsonIgnore]
        public ICollection<Fundraiser>? Fundraisers { get; set; }
    }
}
