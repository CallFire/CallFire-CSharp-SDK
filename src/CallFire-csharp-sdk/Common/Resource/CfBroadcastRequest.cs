using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfBroadcastRequest : CfRequest
    {
        public CfBroadcastRequest(string requestId, CfBroadcast broadcast)
        {
            RequestId = requestId;
            Broadcast = broadcast;
        }

        public CfBroadcast Broadcast { get; set; }
    }
}
