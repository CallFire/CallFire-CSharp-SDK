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
            if (source == null)
            {
                return null;
            }
            var subscriptionFilter = SubscriptionSubscriptionFilterMapper.ToSoapSubscriptionSubscriptionFilter(source.SubscriptionFilter);
            return new Subscription(source.Id, source.Enabled, source.Endpoint,
                EnumeratedMapper.ToSoapEnumerated<NotificationFormat>(source.NotificationFormat.ToString()),
                EnumeratedMapper.ToSoapEnumerated<SubscriptionTriggerEvent>(source.TriggerEvent.ToString()), subscriptionFilter);
        }
    }
}
