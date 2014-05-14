using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
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
            CfSubscription[] newSubscriptionArray = null;
            if (source.Subscription != null)
            {
                var subscription = source.Subscription;
                newSubscriptionArray = new CfSubscription[subscription.Count()];
                for (var i = 0; i < subscription.Count(); i++)
                {
                    var item = subscription[i];
                    newSubscriptionArray[i] = SubscriptionMapper.FromSoapSubscription(item);
                }
            }
            return new CfSubscriptionQueryResult(source.TotalResults, newSubscriptionArray);
        }

        internal static SubscriptionQueryResult ToSoapSubscriptionQueryResult(CfSubscriptionQueryResult source)
        {
            if (source == null)
            {
                return null;
            }
            Subscription[] newSubscriptionArray = null;
            if (source.Subscription != null)
            {
                var subscription = source.Subscription;
                newSubscriptionArray = new Subscription[subscription.Count()];
                for (var i = 0; i < subscription.Count(); i++)
                {
                    var item = subscription[i];
                    newSubscriptionArray[i] = SubscriptionMapper.ToSoapSubscription(item);
                }
            }
            return new SubscriptionQueryResult(source.TotalResults, newSubscriptionArray);
        }

    }
}
