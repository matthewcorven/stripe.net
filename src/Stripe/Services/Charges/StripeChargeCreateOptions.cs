﻿using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Stripe
{
    public class StripeChargeCreateOptions
    {
        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("customer")]
        public string CustomerId { get; set; }

        [JsonIgnore]
        public StripeSourceOptions Source { get; set; }

        [JsonIgnore]
        public string SourceId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("capture")]
        public bool? Capture { get; set; }

        [JsonProperty("statement_descriptor")]
        public string StatementDescriptor { get; set; }

        [JsonProperty("receipt_email")]
        public string ReceiptEmail { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("application_fee")]
        public int? ApplicationFee { get; set; }

        // shipping
    }
}