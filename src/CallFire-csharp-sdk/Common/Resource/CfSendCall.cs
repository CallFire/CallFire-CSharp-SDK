using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSendCall : CfSendRequest
    {
        public CfSendCall(string requestId, CfBroadcastType type, string broadcastName, CfToNumber[] toNumber, 
            bool scrubBroadcastDuplicates, CfBroadcastConfig item)
        {
            RequestId = requestId;
            Type = type;
            BroadcastName = broadcastName;
            ToNumber = toNumber;
            ScrubBroadcastDuplicates = scrubBroadcastDuplicates;
            Item = item;
        }

        /// <summary>
        /// Configuration needed for a Broadcast
        /// </summary>
        public CfBroadcastConfig Item { get; set; }
    }
}
