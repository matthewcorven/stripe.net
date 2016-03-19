﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stripe
{
    public class StripeChargeUpdateOptions
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("receipt_email")]
        public string ReceiptEmail { get; set; }

        [JsonProperty("fraud_details")]
        public Dictionary<string, string> FraudDetails { get; set; }

        // shipping

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}
