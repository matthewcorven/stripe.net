using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Constants
{
    public enum StripeCardBrand
    {
        Unknown,
        [Description("Visa")]
        Visa,
        [Description("American Express")]
        [Display(Name = "American Express")]
        AmericanExpress,
        [Description("MasterCard")]
        MasterCard,
        [Description("Discover")]
        Discover,
        [Description("JCB")]
        JCB,
        [Description("Diners Club")]
        [Display(Name = "Diners Club")]
        DinersClub
    }
}
