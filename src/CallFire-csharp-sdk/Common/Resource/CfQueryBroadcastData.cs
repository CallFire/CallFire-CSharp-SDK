namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryBroadcastData : CfQuery
    {
        public CfQueryBroadcastData(long maxResults, long firstResult, long broadcastId)
        {
            MaxResults = maxResults;
            FirstResult = firstResult;
            BroadcastId = broadcastId;
        }

        public long BroadcastId { get; set; }
    }
}
