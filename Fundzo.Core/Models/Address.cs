using System.ComponentModel.DataAnnotations;

namespace Fundzo.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string PostCode { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public Organisation? Organisation { get; set; }
        public Guid? UserId { get; set; }

    }
}
