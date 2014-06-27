using CallFire_csharp_sdk.Common.DataManagement;
// ReSharper disable once CheckNamespace - This is an extension from Api.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    partial class SubscriptionSubscriptionFilter
    {
        public SubscriptionSubscriptionFilter()
        {
        }
       
        public SubscriptionSubscriptionFilter(CfSubscriptionSubscriptionFilter source)
        {
            if (source.BroadcastId.HasValue)
            {
                BroadcastId = source.BroadcastId.Value;
                BroadcastIdSpecified = true;
            }
            if (source.BatchId.HasValue)
            {
                BatchId = source.BatchId.Value;
                BatchIdSpecified = true;
            }
            FromNumber = source.FromNumber;
            ToNumber = source.ToNumber;
            if (source.Inbound.HasValue)
            {
                Inbound = source.Inbound.Value;
                InboundSpecified = true;
            }
        }
    }
}
