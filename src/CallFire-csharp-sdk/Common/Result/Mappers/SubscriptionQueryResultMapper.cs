using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class SubscriptionQueryResultMapper
    {
        internal static CfSubscriptionQueryResult FromSoapSubscriptionQueryResult(SubscriptionQueryResult source)
        {
            return source == null ? null :
                new CfSubscriptionQueryResult(
                    source.TotalResults,
                    source.Subscription == null ? null : source.Subscription.Select(SubscriptionMapper.FromSoapSubscription).ToArray());
        }

        internal static SubscriptionQueryResult ToSoapSubscriptionQueryResult(CfSubscriptionQueryResult source)
        {
            return source == null ? null :
                new SubscriptionQueryResult(
                    source.TotalResults,
                    source.Subscription == null ? null : source.Subscription.Select(SubscriptionMapper.ToSoapSubscription).ToArray());
        }
    }
}
