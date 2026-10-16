using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fundzo.Core.Models
{

    public class FundraiserType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public ICollection<Fundraiser>? Fundraisers { get; set; }
    }
}