using System;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSendText : CfSendRequest
    {
        public CfTextBroadcastConfig TextBroadcastConfig { get; set; }

        public long BroadcastId { get; set; }

        public Boolean UseDefaultBroadcast { get; set; }
    }
}
