using Newtonsoft.Json;

namespace Stripe
{
    public class StripeRefundListOptions : StripeListOptions
    {
        [JsonProperty("charge")]
        public string Charge { get; set; }
    }
}