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

        public long BroadcastId { get; set; }

        public string Name { get; set; }

        public object[] Items { get; set; }

        public bool ScrubBroadcastDuplicates { get; set; }
    }
}
