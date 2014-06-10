namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryBroadcastData : CfQuery
    {
        public CfQueryBroadcastData()
        {
        }
        
        public CfQueryBroadcastData(long maxResults, long firstResult, long broadcastId)
        {
            MaxResults = maxResults;
            FirstResult = firstResult;
            BroadcastId = broadcastId;
        }

        /// <summary>
        /// Unique ID of Broadcast
        /// </summary>
        public long BroadcastId { get; set; }
    }
}
