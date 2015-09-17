using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Constants
{
    public enum ErrorCode
    {
        None = 0,
        [Description("invalid_number")]
        [Display(Name= "The card number is not a valid credit card number.")]
        InvalidNumber,
        [Description("invalid_expiry_month")]
        [Display(Name = "The card's expiration month is invalid.")]
        InvalidExpiryMonth,
        [Description("invalid_expiry_year")]
        [Display(Name = "The card's expiration year is invalid.")]
        InvalidExpiryYear,
        [Description("invalid_cvc")]
        [Display(Name = "The card's security code is invalid.")]
        InvalidCvc,
        [Description("incorrect_number")]
        [Display(Name = "The card number is incorrect.")]
        IncorrectNumber,
        [Description("expired_card")]
        [Display(Name = "The card has expired.")]
        ExpiredCard,
        [Description("incorrect_cvc")]
        [Display(Name = "The card's security code is incorrect.")]
        IncorrectCvc,
        [Description("incorrect_zip")]
        [Display(Name = "The card's zip code failed validation.")]
        IncorrectZip,
        [Description("card_declined")]
        [Display(Name = "The card was declined.")]
        CardDeclined,
        [Description("missing")]
        [Display(Name = "There is no card on a customer that is being charged.")]
        Missing,
        [Description("processing_error")]
        [Display(Name = "An error occurred while processing the card.")]
        ProcessingError
    }
}
