// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class QueryBroadcasts
    {
        public QueryBroadcasts(long maxResults, long firstResult, string type, bool running, string labelName)
        {
            MaxResults = maxResults;
            FirstResult = firstResult;
            Type = type;
            Running = running;
            LabelName = labelName;
        }

        public QueryBroadcasts()
        {
        }
    }
}
