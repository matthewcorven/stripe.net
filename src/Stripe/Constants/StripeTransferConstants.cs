using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Stripe.Constants
{
    public enum StripeTransferStatus
    {
        Unknown = 0,
        [Description("paid")]
        Paid,
        [Description("pending")]
        Pending,
        [Description("in_transit")]
        InTransit,
        [Description("canceled")]
        Canceled,
        [Description("failed")]
        Failed
    }
}
