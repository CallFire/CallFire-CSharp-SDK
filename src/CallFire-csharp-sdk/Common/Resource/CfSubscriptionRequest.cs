using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSubscriptionRequest
    {
        public CfSubscriptionRequest(string requestId, CfSubscription suscription)
        {
            RequestId = requestId;
            Subscription = suscription;
        }

        public string RequestId { get; set; }

        public CfSubscription Subscription { get; set; }
    }
}
