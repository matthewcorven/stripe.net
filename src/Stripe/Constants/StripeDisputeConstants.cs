using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Stripe.Infrastructure;

namespace Stripe.Constants
{
    public enum StripeDisputeReason
    {
        Unknown = 0,
        [Description("duplicate")]
        [EnumHelper.LongDescription("The customer says you charged their card multiple times for the same product or service.")]
        Duplicate,
        [Description("fraudulent")]
        [EnumHelper.LongDescription("The owner of the card says that they didn’t authorize the charge. This is the most common reason for a dispute and can happen if the card was lost or stolen. It can also happen if the cardholder doesn’t recognize the charge as it appears on the billing statement from their bank.")]
        Fradulent,
        [Description("subscription_canceled")]
        [EnumHelper.LongDescription("The customer says that you continued to charge them after a subscription was canceled.")]
        [Display(Name = "Subscription Canceled")]
        SubscriptionCancelled,
        [Description("product_unacceptable")]
        [EnumHelper.LongDescription("The product or service was received but was defective, damaged, or not as described.")]
        [Display(Name = "Product Unacceptable")]
        ProductUnacceptable,
        [Description("product_not_received")]
        [EnumHelper.LongDescription("The customer says they did not receive the products or services purchased.")]
        [Display(Name = "Product Not Received")]
        ProductNotReceived,
        [Description("unrecognized")]
        [EnumHelper.LongDescription("The customer doesn’t recognize the charge appearing on their card statement.")]
        Unrecognized,
        [Description("credit_not_processed")]
        [EnumHelper.LongDescription("The customer says that the purchased product was returned or the transaction was otherwise canceled, but you have not yet refunded or credited the customer.")]
        [Display(Name = "Credit Not Processed")]
        CreditNotProcessed,
        [Description("incorrect_account_details")]
        [EnumHelper.LongDescription("The customer's bank reported that incorrect account details were used while attempting the transaction.")]
        [Display(Name = "Incorrect Account Details")]
        IncorrectAccountDetails,
        [Description("insufficient_funds")]
        [EnumHelper.LongDescription("The customer's bank reported that there were in sufficient funds in the account at the time of the attempted transaction.")]
        [Display(Name = "Insufficient Funds")]
        InsufficientFunds,
        [Description("bank_cannot_process")]
        [EnumHelper.LongDescription("The customer's bank reported that it was unable to process the transaction.")]
        [Display(Name = "Bank Cannot Process")]
        BankCannotProcess,
        [Description("debit_not_authorized")]
        [EnumHelper.LongDescription("The customer's bank reported that the debit transaction could not be authorized.")]
        [Display(Name = "Debit Not Authorized")]
        DebitNotAuthorized,
        [Description("general")]
        [EnumHelper.LongDescription("This is an uncategorized dispute. Since these are most commonly fraudulent, we recommend following the suggestion listed for that type.")]
        General
    }

    public enum StripeDisputeStatus
    {
        [Description("warning_needs_response")]
        [EnumHelper.LongDescription("An inquiry has been opened by the cardholder's bank, and no evidence has yet been provided for the case.")]
        [Display(Name = "Warning Needs Response")]
        WarningNeedsResponse,
        [Description("warning_under_review")]
        [EnumHelper.LongDescription("An inquiry was been opened by the cardholder's bank. Evidence has been provided, and the cardholder’s bank is reviewing it.")]
        [Display(Name = "Warning Under Review")]
        WarningUnderReview,
        [Description("warning_closed")]
        [EnumHelper.LongDescription("An inquiry was been opened by the cardholder's bank. The inquiry has timed out and did not escalate into a full chargeback.")]
        [Display(Name = "Warning Closed")]
        WarningClosed,
        [Description("needs_response")]
        [EnumHelper.LongDescription("Cardholder has disputed this charge. A response is needed.")]
        [Display(Name = "Needs Response")]
        NeedsResponse,
        [Description("response_disabled")]
        [EnumHelper.LongDescription("Cardholder disputed this charge. Dispute has been responded to the maximum number of times (5).")]
        [Display(Name = "Response Disabled")]
        ResponseDisabled,
        [Description("under_review")]
        [EnumHelper.LongDescription("Cardholder has disputed this charge. Evidence has been provided, and the cardholder’s bank is reviewing it.")]
        [Display(Name = "Under Review")]
        UnderReview,
        [Description("charge_refunded")]
        [EnumHelper.LongDescription("An inquiry was been opened by the cardholder's bank. A full refund was issues before the inquiry escalated into a full chargeback.")]
        [Display(Name = "Charge Refunded")]
        ChargeRefunded,
        [Description("won")]
        [EnumHelper.LongDescription("Cardholder disputed this charge. Upon review, it was resolved in your favor.")]
        Won,
        [Description("lost")]
        [EnumHelper.LongDescription("Cardholder disputed this charge. Upon review, it was resolved in the cardholder's favor.")]
        Lost
    }
}
