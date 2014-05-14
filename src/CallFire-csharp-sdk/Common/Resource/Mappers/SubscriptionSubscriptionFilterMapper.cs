using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class SubscriptionSubscriptionFilterMapper
    {
        internal static CfSubscriptionSubscriptionFilter FromSoapSubscriptionSubscriptionFilter(SubscriptionSubscriptionFilter source)
        {
            return source == null ? null : new CfSubscriptionSubscriptionFilter(source.BroadcastId, source.BatchId, source.FromNumber, source.ToNumber, source.Inbound);
        }

        internal static SubscriptionSubscriptionFilter ToSoapSubscriptionSubscriptionFilter(CfSubscriptionSubscriptionFilter source)
        {
            return source == null ? null : new SubscriptionSubscriptionFilter(source.BroadcastId, source.BatchId, source.FromNumber, source.ToNumber, source.Inbound);
        }
    }
}
