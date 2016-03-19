using System;
using System.Collections.Generic;

namespace Stripe
{
    public class StripeRefundService : StripeService
    {
        public StripeRefundService(string apiKey = null) : base(apiKey) { }

        public bool ExpandCharge { get; set; }
        public bool ExpandBalanceTransaction { get; set; }

        public virtual StripeRefund Create(StripeRefundCreateOptions createOptions = null, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = this.ApplyAllParameters(createOptions, Urls.Refunds, false);
            url = this.ApplyAllParameters(null, url, false);

            var response = Requestor.PostString(url, requestOptions);

            return Mapper<StripeRefund>.MapFromJson(response);
        }

        public virtual StripeRefund Get(string refundId, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}", Urls.Refunds, refundId);
            url = this.ApplyAllParameters(null, url, false);

            var response = Requestor.GetString(url, requestOptions);

            return Mapper<StripeRefund>.MapFromJson(response);
        }

        public virtual StripeRefund Update(string refundId, StripeRefundUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}", Urls.Refunds, refundId);
            url = this.ApplyAllParameters(updateOptions, url, false);

            var response = Requestor.PostString(url, requestOptions);

            return Mapper<StripeRefund>.MapFromJson(response);
        }

        public virtual IEnumerable<StripeRefund> List(StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = Urls.Charges;
            url = this.ApplyAllParameters(listOptions, url, true);

            var response = Requestor.GetString(url, requestOptions);

            return Mapper<StripeRefund>.MapCollectionFromJson(response);
        }
    }
}
