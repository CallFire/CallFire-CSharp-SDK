using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSubscriptionRequest : CfRequest
    {
        public CfSubscriptionRequest(string requestId, CfSubscription suscription)
        {
            RequestId = requestId;
            Subscription = suscription;
        }

        /// <summary>
        /// Subscription
        /// </summary>
        public CfSubscription Subscription { get; set; }
    }
}
