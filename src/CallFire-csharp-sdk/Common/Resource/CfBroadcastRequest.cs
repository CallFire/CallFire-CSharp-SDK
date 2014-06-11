using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfBroadcastRequest : CfRequest
    {
        public CfBroadcastRequest()
        {
        }

        public CfBroadcastRequest(string requestId, CfBroadcast broadcast)
        {
            RequestId = requestId;
            Broadcast = broadcast;
        }
        
        /// <summary>
        /// A Text, Ivr, or Voice Broadcast
        /// </summary>
        public CfBroadcast Broadcast { get; set; }
    }
}
