// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Subscription
    {
        public Subscription(long identifier, bool enabled, string endpoint, NotificationFormat notificationFormat,
            SubscriptionTriggerEvent triggerEvent, SubscriptionSubscriptionFilter subscriptionFilter)
        {
            id = identifier;
            Enabled = enabled;
            Endpoint = endpoint;
            NotificationFormat = notificationFormat;
            TriggerEvent = triggerEvent;
            TriggerEventSpecified = true;
            SubscriptionFilter = subscriptionFilter;
        }
    }
}
