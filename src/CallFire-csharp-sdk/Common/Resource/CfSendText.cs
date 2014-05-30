using System;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSendText : CfSendRequest
    {
        public CfSendText(string requestId, CfBroadcastType type, string broadcastName, CfToNumber[] toNumber, bool scrubBroadcastDuplicates,
            CfTextBroadcastConfig textBroadcastConfig, long broadcastId, Boolean useDefaultBroadcast)
        {
            RequestId = requestId;
            Type = type;
            BroadcastName = broadcastName;
            ToNumber = toNumber;
            ScrubBroadcastDuplicates = scrubBroadcastDuplicates;
            TextBroadcastConfig = textBroadcastConfig;
            BroadcastId = broadcastId;
            UseDefaultBroadcast = useDefaultBroadcast;
        }

        public CfTextBroadcastConfig TextBroadcastConfig { get; set; }

        public long BroadcastId { get; set; }

        public Boolean UseDefaultBroadcast { get; set; }
    }
}
