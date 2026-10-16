using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fundzo.Core.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        [JsonIgnore]
        public ICollection<Donation>? Donations { get; set; }
        [JsonIgnore]
        public ICollection<Fundraiser>? Fundraisers { get; set; }
        [JsonIgnore]
        public ICollection<Payment>? Payments { get; set; }
    }
}
