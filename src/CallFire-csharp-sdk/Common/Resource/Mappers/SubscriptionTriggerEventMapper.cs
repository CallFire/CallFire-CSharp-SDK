using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class SubscriptionTriggerEventMapper
    {
        private static readonly TwoWayMapper<SubscriptionTriggerEvent, CfSubscriptionTriggerEvent> DicSubscriptionTriggerEvent = new TwoWayMapper
           <SubscriptionTriggerEvent, CfSubscriptionTriggerEvent>
        {
            {SubscriptionTriggerEvent.CAMPAIGN_FINISHED, CfSubscriptionTriggerEvent.CampaignFinished},
            {SubscriptionTriggerEvent.CAMPAIGN_STARTED, CfSubscriptionTriggerEvent.CampaignStarted},
            {SubscriptionTriggerEvent.CAMPAIGN_STOPPED, CfSubscriptionTriggerEvent.CampaignStopped},
            {SubscriptionTriggerEvent.INBOUND_CALL_FINISHED, CfSubscriptionTriggerEvent.InboundCallFinished},
            {SubscriptionTriggerEvent.INBOUND_TEXT_FINISHED, CfSubscriptionTriggerEvent.InboundTextFinished},
            {SubscriptionTriggerEvent.OUTBOUND_CALL_FINISHED, CfSubscriptionTriggerEvent.OutboundCallFinished},
            {SubscriptionTriggerEvent.OUTBOUND_TEXT_FINISHED, CfSubscriptionTriggerEvent.OutboundTextFinished},
            {SubscriptionTriggerEvent.UNDEFINED_EVENT, CfSubscriptionTriggerEvent.UndefinedEvent}
        };

        internal static CfSubscriptionTriggerEvent FromSoapSubscriptionTriggerEvent(SubscriptionTriggerEvent source)
        {
            if (DicSubscriptionTriggerEvent.ContainsKey(source))
            {
                return DicSubscriptionTriggerEvent[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }

        internal static SubscriptionTriggerEvent ToSoapSubscriptionTriggerEvent(CfSubscriptionTriggerEvent source)
        {
            if (DicSubscriptionTriggerEvent.ContainsKey(source))
            {
                return DicSubscriptionTriggerEvent[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }
    }
}
