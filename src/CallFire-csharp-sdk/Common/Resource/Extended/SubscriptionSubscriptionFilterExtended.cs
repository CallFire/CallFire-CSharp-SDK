// ReSharper disable once CheckNamespace - This is an extension from Api.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    partial class SubscriptionSubscriptionFilter
    {
        public SubscriptionSubscriptionFilter(long broadcastId, long batchId, string fromNumber, string toNumber, bool inbound)
        {
            BroadcastId = broadcastId;
            BatchId = batchId;
            FromNumber = fromNumber;
            ToNumber = toNumber;
            Inbound = inbound;
        }
    }
}
