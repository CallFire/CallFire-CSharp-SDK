namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryContactBatches : CfQuery
    {
        public CfQueryContactBatches(long maxResults, long firstResult, long broadcastId)
        {
            MaxResults = maxResults;
            FirstResult = firstResult;
            BroadcastId = broadcastId;
        }

        public long BroadcastId { get; set; }
    }
}
