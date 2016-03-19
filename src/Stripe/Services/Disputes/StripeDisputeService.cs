namespace Stripe
{
    public class StripeDisputeService : StripeService
    {
        public StripeDisputeService(string apiKey = null) : base(apiKey) { }

        public bool ExpandCharge { get; set; }

        public virtual StripeDispute Get(string disputeId, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}", Urls.Disputes, disputeId);
            url = this.ApplyAllParameters(null, url, false);

            var response = Requestor.GetString(url, requestOptions);

            return Mapper<StripeDispute>.MapFromJson(response);
        }

        public virtual StripeDispute Update(string disputeId, StripeDisputeUpdateOptions updateOptions = null, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}", Urls.Disputes, disputeId);
            url = this.ApplyAllParameters(updateOptions, url, true);

            var response = Requestor.PostString(url, requestOptions);

            return Mapper<StripeDispute>.MapFromJson(response);
        }


        public virtual StripeDispute Close(string disputeId, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}/close", Urls.Charges, disputeId);
            url = this.ApplyAllParameters(null, url, false);

            var response = Requestor.PostString(url, requestOptions);

            return Mapper<StripeDispute>.MapFromJson(response);
        }
    }
}