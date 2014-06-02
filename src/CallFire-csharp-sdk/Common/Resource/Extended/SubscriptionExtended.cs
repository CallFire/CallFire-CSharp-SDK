using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Subscription
    {
        public Subscription(CfSubscription source)
        {
            if (source.Id.HasValue)
            {
                id = source.Id.Value;
                idSpecified = true;
            }
            if (source.Enabled.HasValue)
            {
                Enabled = source.Enabled.Value;
                EnabledSpecified = true;
            }
            Endpoint = source.Endpoint;
            NotificationFormat = EnumeratedMapper.ToSoapEnumerated<NotificationFormat>(source.NotificationFormat.ToString());
            if (source.TriggerEvent.HasValue)
            {
                TriggerEvent = EnumeratedMapper.ToSoapEnumerated<SubscriptionTriggerEvent>(source.TriggerEvent.ToString());
                TriggerEventSpecified = true;
            }
            SubscriptionFilter = SubscriptionSubscriptionFilterMapper.ToSoapSubscriptionSubscriptionFilter(source.SubscriptionFilter);
        }
    }
}
