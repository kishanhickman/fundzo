namespace Fundzo.Api.Resources
{
    public class PaymentMethodResource
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public bool Enabled { get; set; }
    }
}