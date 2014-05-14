namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryBroadcastSchedules : CfQuery
    {
        public CfQueryBroadcastSchedules(long maxResult, long firstResult, long broadcastId)
        {
            MaxResults = maxResult;
            FirstResult = firstResult;
            BroadcastId = broadcastId;
        }

        public long BroadcastId { get; set; }
    }
}
