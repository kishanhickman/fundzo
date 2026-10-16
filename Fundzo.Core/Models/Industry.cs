using System.ComponentModel.DataAnnotations;

namespace Fundzo.Core.Models
{
    public class Industry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Organisation? Organisation { get; set; }
    }
}
