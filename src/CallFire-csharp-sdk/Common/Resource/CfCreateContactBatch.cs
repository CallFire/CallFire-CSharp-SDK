namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateContactBatch
    {
        public string RequestId { get; set; }

        public long BroadcastId { get; set; }

        public string Name { get; set; }

        public object[] Items { get; set; }

        public bool ScrubBroadcastDuplicates { get; set; }
    }
}
