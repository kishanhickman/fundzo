using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fundzo.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public ICollection<Fundraiser>? Fundraisers { get; set; }

    }
}
