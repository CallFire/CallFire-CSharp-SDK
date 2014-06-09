namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateContactBatch
    {
        public CfCreateContactBatch(string requestId, long broadcastId, string name, object[] items, bool scrubBroadcastDuplicates)
        {
            RequestId = requestId;
            BroadcastId = broadcastId;
            Name = name;
            Items = items;
            ScrubBroadcastDuplicates = scrubBroadcastDuplicates;
        }

        public string RequestId { get; set; }

        /// <summary>
        /// Id of Broadcast
        /// </summary>
        public long BroadcastId { get; set; }

        /// <summary>
        /// Name of Contact Batch
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of E.164 11 digit numbers space or comma separated and contact list id
        /// </summary>
        public object[] Items { get; set; }

        public bool ScrubBroadcastDuplicates { get; set; }
    }
}
