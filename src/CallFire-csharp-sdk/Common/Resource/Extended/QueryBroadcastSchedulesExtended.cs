using CallFire_csharp_sdk.Common.Resource;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class QueryBroadcastSchedules
    {
        public QueryBroadcastSchedules(long maxResults, long firstResult, long broadcastId)
        {
            MaxResults = maxResults;
            FirstResult = firstResult;
            BroadcastId = broadcastId;
        }

        public QueryBroadcastSchedules(CfQueryBroadcastData source)
        {
            MaxResults = source.MaxResults;
            FirstResult = source.FirstResult;
            BroadcastId = source.BroadcastId;
        }

        public QueryBroadcastSchedules()
        {
        }
    }
}
