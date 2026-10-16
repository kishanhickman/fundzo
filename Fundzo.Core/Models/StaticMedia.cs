using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fundzo.Core.Models
{
    public class StaticMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string BlobUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public string Page { get; set; }
        public string Layout { get; set; }
        [JsonIgnore]
        public ICollection<FundraiserMedia>? FundraiserMedias { get; set; }
    }
}
