using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class SubscriptionQueryResultMapper
    {
        internal static CfSubscriptionQueryResult FromSoapSubscriptionQueryResult(SubscriptionQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var subscription = source.Subscription == null ? null
                                : source.Subscription.Select(SubscriptionMapper.FromSoapSubscription).ToArray();
            return new CfSubscriptionQueryResult(source.TotalResults, subscription);
        }

        internal static SubscriptionQueryResult ToSoapSubscriptionQueryResult(CfSubscriptionQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var subscription = source.Subscription == null ? null
                                : source.Subscription.Select(SubscriptionMapper.ToSoapSubscription).ToArray();
            return new SubscriptionQueryResult(source.TotalResults, subscription);
        }
    }
}
