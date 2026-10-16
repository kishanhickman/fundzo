using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fundzo.Core.Models
{
    public class FundraiserMedia
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int FundraiserId { get; set; }
        [JsonIgnore]
        public Fundraiser Fundraiser { get; set; }
        public int StaticMediaId { get; set; }
        public StaticMedia StaticMedia { get; set; }
    }
}
