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
                NotificationFormatMapper.FromSoapNotificationFormat(source.NotificationFormat),
                SubscriptionTriggerEventMapper.FromSoapSubscriptionTriggerEvent(source.TriggerEvent), subscriptionFilter);
        }

        internal static Subscription ToSoapSubscription(CfSubscription source)
        {
            if (source == null)
            {
                return null;
            }
            var subscriptionFilter = SubscriptionSubscriptionFilterMapper.ToSoapSubscriptionSubscriptionFilter(source.SubscriptionFilter);
            return new Subscription(source.Id, source.Enabled, source.Endpoint,
                NotificationFormatMapper.ToSoapNotificationFormat(source.NotificationFormat),
                SubscriptionTriggerEventMapper.ToSoapSubscriptionTriggerEvent(source.TriggerEvent), subscriptionFilter);
        }
    }
}
