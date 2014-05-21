using System;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSendText : CfRequest
    {
        public CfBroadcastType Type { get; set; }

        public string BroadcastName { get; set; }

        public string ToNumber { get; set; }

        public bool ScrubBroadcastDuplicates { get; set; }

        public CfTextBroadcastConfig TextBroadcastConfig { get; set; }

        public long BroadcastId { get; set; }

        public Boolean UseDefaultBroadcast { get; set; }
    }
}
