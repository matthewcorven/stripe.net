﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Infrastructure;
using Newtonsoft.Json.Linq;
using Stripe.Constants;

namespace Stripe
{
    public class StripeTransfer : StripeObject
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(StripeDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("date")]
        [JsonConverter(typeof(StripeDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("reversals")]
        public StripeList<StripeTransferReversal> StripeTransferReversalList { get; set; }

        [JsonProperty("reversed")]
        public bool Reversed { get; set; }

        [JsonIgnore]
        public StripeTransferStatus Status { get; set; }

        [JsonProperty("status")]
        internal string InternalStatus
        {
            set
            {
                Status = EnumHelper.GetEnumValueFromDescription<StripeTransferStatus>(value);
            }
        }
        
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount_reversed")]
        public int AmountReversed { get; set; }

        public string BalanceTransactionId { get; set; }
        public StripeBalanceTransaction BalanceTransaction { get; set; }

        [JsonProperty("balance_transaction")]
        internal object InternalBalanceTransaction
        {
            set
            {
                ExpandableProperty<StripeBalanceTransaction>.Map(value, s => BalanceTransactionId = s, o => BalanceTransaction = o);
            }
        }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("destination_payment")]
        public string DestinationPayment { get; set; }

        [JsonProperty("failure_code")]
        public string FailureCode { get; set; }

        [JsonProperty("failure_message")]
        public string FailureMessage { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("bank_account")]
        public StripeBankAccount StripeBankAccount { get; set; }

        [JsonProperty("card")]
        public StripeCard Card { get; set; }

        public string RecipientId { get; set; }

        [JsonIgnore]
        public StripeRecipient Recipient { get; set; }

        [JsonProperty("recipient")]
        internal object InternalRecipient
        {
            set
            {
                ExpandableProperty<StripeRecipient>.Map(value, s => RecipientId = s, o => Recipient = o);
            }
        }

        [JsonProperty("source_transaction")]
        public string SourceTransaction { get; set; }

        [JsonProperty("source_type")]
        public string SourceType { get; set; }

        [JsonProperty("statement_descriptor")]
        public string StatementDescriptor { get; set; }
    }
}