using Fundzo.Api.Resources.StaticMedia;

namespace Fundzo.Api.Resources.Fundraiser
{
    public class FundraiserMediaResource
    {
        public int Id { get; set; }
        public int FundraiserId { get; set; }
        public FundraiserResource Fundraiser { get; set; }
        public int StaticMediaId { get; set; }
        public StaticMediaResource StaticMedia { get; set; }
    }
}
