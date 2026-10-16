using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fundzo.Core.Models
{

    public class FundraiserStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public ICollection<Fundraiser>? Fundraisers { get; set; }
    }

}


/* public enum FundraiserStatus
{
    Planned,
    Active,
    InActive,
    Complete
}*/