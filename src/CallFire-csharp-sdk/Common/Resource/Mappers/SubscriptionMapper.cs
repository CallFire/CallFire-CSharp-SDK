using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class SubscriptionMapper
    {
        internal static CfSubscription FromSoapSubscription(Subscription source)
        {
            if (source == null)
            {
                return null;
            }
            var subscriptionFilter = SubscriptionSubscriptionFilterMapper.FromSoapSubscriptionSubscriptionFilter(source.SubscriptionFilter);
            return new CfSubscription(source.id, source.Enabled, source.Endpoint,
                EnumeratedMapper.EnumFromSoapEnumerated<CfNotificationFormat>(source.NotificationFormat.ToString()),
                EnumeratedMapper.EnumFromSoapEnumerated<CfSubscriptionTriggerEvent>(source.TriggerEvent.ToString()), subscriptionFilter);
        }

        internal static Subscription ToSoapSubscription(CfSubscription source)
        {
            return source == null ? null : new Subscription(source);
        }
    }
}
