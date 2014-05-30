using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSendRequest : CfRequest
    {
        public CfBroadcastType Type { get; set; }

        public string BroadcastName { get; set; }

        public CfToNumber[] ToNumber { get; set; }

        public bool ScrubBroadcastDuplicates { get; set; }
    }
}
