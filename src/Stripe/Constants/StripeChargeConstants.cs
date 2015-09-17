using System.ComponentModel;

namespace Stripe.Constants
{
    public enum StripeChargeStatus
    {
        Unknown = 0,
        [Description("succeeded")]
        Succeeded,
        [Description("failed")]
        Failed
    }
}
