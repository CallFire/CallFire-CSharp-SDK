using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSendRequest : CfRequest
    {
        /// <summary>
        /// Type of Broadcast
        /// </summary>
        public CfBroadcastType Type { get; set; }

        /// <summary>
        /// Title of Broadcast
        /// </summary>
        public string BroadcastName { get; set; }

        /// <summary>
        /// List of E.164 11 digit numbers 
        /// </summary>
        public CfToNumber[] ToNumber { get; set; }

        /// <summary>
        /// Scrub duplicates
        /// </summary>
        public bool ScrubBroadcastDuplicates { get; set; }
    }
}
