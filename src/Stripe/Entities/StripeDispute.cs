using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Constants;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeDispute : StripeObject
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("livemode")]
        public bool? LiveMode { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        #region Expandable Charge
        public string ChargeId { get; set; }

        [JsonIgnore]
        public StripeCharge Charge { get; set; }

        [JsonProperty("charge")]
        internal object InternalCharge
        {
            set
            {
                ExpandableProperty<StripeCharge>.Map(value, s => ChargeId = s, o => Charge = o);
            }
        }
        #endregion

        [JsonProperty("created")]
        [JsonConverter(typeof(StripeDateTimeConverter))]
        public DateTime? Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonIgnore]
        public StripeDisputeReason Reason { get; set; }

        [JsonProperty("reason")]
        internal string InternalReason
        {
            set
            {
                Reason = EnumHelper.GetEnumValueFromDescription<StripeDisputeReason>(value);
            }
        }

        [JsonIgnore]
        public StripeDisputeStatus Status { get; set; }

        [JsonProperty("status")]
        internal string InternalStatus
        {
            set
            {
                Status = EnumHelper.GetEnumValueFromDescription<StripeDisputeStatus>(value);
            }
        }
        [JsonProperty("balance_transactions")]
        public List<StripeBalanceTransaction> BalanceTransactions { get; set; }

        // needs evidence object
        [JsonProperty("evidence_details")]
        public StripeDisputeEvidenceDetails EvidenceDetails { get; set; }

        // needs evidence_details
        [JsonProperty("evidence")]
        public StripeDisputeEvidence Evidence { get; set; }

        [JsonProperty("is_charge_refundable")]
        public bool IsChargeRefundable { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }

    public class StripeDisputeEvidenceDetails
    {

        [JsonConverter(typeof(StripeDateTimeConverter))]
        [JsonProperty("due_by")]
        public DateTime? DueBy { get; set; }

        [JsonProperty("past_due")]
        public bool PastDue { get; set; }

        [JsonProperty("has_evidence")]
        public bool HasEvidence { get; set; }

        [JsonProperty("submission_count")]
        public int SubmissionCount { get; set; }
    }

    public class StripeDisputeEvidence
    {

        [JsonProperty("product_description")]
        [EnumHelper.LongDescription("A description of the product or service which was sold.")]
        public string ProductDescription { get; set; }

        [JsonProperty("customer_name")]
        [EnumHelper.LongDescription("The name of the customer.")]
        public string CustomerName { get; set; }

        [JsonProperty("customer_email_address")]
        [EnumHelper.LongDescription("The email address of the customer.")]
        public string CustomerEmailAddress { get; set; }

        [JsonProperty("customer_purchase_ip")]
        [EnumHelper.LongDescription("The IP address that the customer used when making the purchase. When Stripe compiles your evidence into a single document, this will be automatically expanded to include geographical data.")]
        public string CustomerPurchaseIp { get; set; }

        [JsonProperty("customer_signature")]
        [EnumHelper.LongDescription("A relevant document or contract showing the customer’s signature.")]
        public string CustomerSignature { get; set; }

        [JsonProperty("billing_address")]
        [EnumHelper.LongDescription("The billing addess provided by the customer.")]
        public string BillingAddress { get; set; }

        [JsonProperty("receipt")]
        [EnumHelper.LongDescription("Any receipt or message sent to the customer notifying them of the charge. This field will be automatically filled with a Stripe generated email receipt if any such receipt was sent.")]
        public string Receipt { get; set; }

        [JsonProperty("shipping_address")]
        [EnumHelper.LongDescription("The address to which a physical product was shipped. You should try to include as much complete address information as possible.")]
        public string ShippingAddress { get; set; }

        [JsonProperty("shipping_date")]
        [EnumHelper.LongDescription("The date on which a physical product began its route to the shipping address, in a clear human-readable format.")]
        public string ShippingDate { get; set; }

        [JsonProperty("shipping_carrier")]
        [EnumHelper.LongDescription("The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc. If multiple carriers were used for this purchase, please separate them with commas.")]
        public string ShippingCarrier { get; set; }

        [JsonProperty("shipping_tracking_number")]
        [EnumHelper.LongDescription("The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas. When we compile your evidence into a single document, these tracking numbers will be expanded to include detailed delivery information from the carrier.")]
        public string ShippingTrackingNumber { get; set; }

        [JsonProperty("shipping_documentation")]
        [EnumHelper.LongDescription("Documentation showing proof that a product was shipped to the customer at the same address the customer provided to you. This could include a copy of the shipment receipt, shipping label, etc, and should show the full shipping address of the customer, if possible.")]
        public string ShippingDocumentation { get; set; }

        [JsonProperty("access_activity_log")]
        [EnumHelper.LongDescription("Any server or activity logs showing proof that the customer accessed or downloaded the purchased digital product. This information should include IP addresses, corresponding timestamps, and any detailed recorded activity.")]
        public string AccessActivityLog { get; set; }

        [JsonProperty("service_date")]
        [EnumHelper.LongDescription("The date on which the customer received or began receiving the purchased service, in a clear human-readable format.")]
        public string ServiceDate { get; set; }

        [JsonProperty("service_documentation")]
        [EnumHelper.LongDescription("Documentation showing proof that a service was provided to the customer. This could include a copy of a signed contract, work order, or other form of written agreement.")]
        public string ServiceDocumentation { get; set; }

        [JsonProperty("duplicate_charge_id")]
        [EnumHelper.LongDescription("The Stripe ID for the prior charge which appears to be a duplicate of the disputed charge.")]
        public string DuplicateChargeId { get; set; }

        [JsonProperty("duplicate_charge_explanation")]
        [EnumHelper.LongDescription("An explanation of the difference between the disputed charge and the prior charge that appears to be a duplicate.")]
        public string DuplicateChargeExplanation { get; set; }

        [JsonProperty("duplicate_charge_documentation")]
        [EnumHelper.LongDescription("Documentation for the prior charge that can uniquely identify the charge, such as a receipt, shipping label, work order, etc. This document should be paired with a similar document from the disputed payment that proves the two payments are separate.")]
        public string DuplicateChargeDocumentation { get; set; }

        [JsonProperty("refund_policy")]
        [EnumHelper.LongDescription("Your refund policy, as shown to the customer.")]
        public string RefundPolicy { get; set; }

        [JsonProperty("refund_policy_disclosure")]
        [EnumHelper.LongDescription("An explanation of how and when the customer was shown your refund policy prior to purchase.")]
        public string RefundPolicyDisclosure { get; set; }

        [JsonProperty("refund_refusal_explanation")]
        [EnumHelper.LongDescription("A justification for why the customer is not entitled to a refund.")]
        public string RefundRefusalExplanation { get; set; }

        [JsonProperty("cancellation_policy")]
        [EnumHelper.LongDescription("Your subscription cancellation policy, as shown to the customer.")]
        public string CancellationPolicy { get; set; }

        [JsonProperty("cancellation_policy_disclosure")]
        [EnumHelper.LongDescription("An explanation of how and when the customer was shown your cancellation policy prior to purchase.")]
        public string CancellationPolicyDisclosure { get; set; }

        [JsonProperty("cancellation_rebuttal")]
        [EnumHelper.LongDescription("A justification for why the customer’s subscription was not canceled.")]
        public string CancellationRebuttal { get; set; }

        [JsonProperty("customer_communication")]
        [EnumHelper.LongDescription("Any communication with the customer that you feel is relevant to your case (for example emails proving that they received the product or service, or demonstrating their use of or satisfaction with the product or service).")]
        public string CustomerCommunication { get; set; }

        [JsonProperty("uncategorized_file")]
        [EnumHelper.LongDescription("Any additional evidence or statements.")]
        public string UncategorizedFile { get; set; }

        [JsonProperty("uncategorized_text")]
        [EnumHelper.LongDescription("Any additional evidence or statements.")]
        public string UncategorizedText { get; set; }


    }


}