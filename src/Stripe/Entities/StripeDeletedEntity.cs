using Newtonsoft.Json;

namespace Stripe
{
    public class StripeDeletedEntity :StripeObject
    {
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

    }
}
