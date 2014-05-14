using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSubscriptionRequest
    {
        public string RequestId { get; set; }

        public CfSubscription Subscription { get; set; }
    }
}
