using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stripe.Services.Charges
{
    public class StripeChargeUpdateOptions
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("receipt_email")]
        public string ReceiptEmail { get; set; }

        // fraud_details

        // shipping

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}
