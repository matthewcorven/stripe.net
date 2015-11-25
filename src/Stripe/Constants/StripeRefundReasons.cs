using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stripe
{
    public enum StripeRefundReason
    {
        Unknown = 0,
        [Description("duplicate")]
        Duplicate,
        [Description("fraudulent")]
        Fradulent,
        [Description("requested_by_customer")]
        [Display(Name= "Requested By Customer")]
        RequestedByCustomer
    }
}