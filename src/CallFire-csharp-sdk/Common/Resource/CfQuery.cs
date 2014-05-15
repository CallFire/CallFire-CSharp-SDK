namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQuery
    {
        public long MaxResults { get; set; }

        public long FirstResult { get; set; }

        public CfQuery()
        {
            MaxResults = 1000;
            FirstResult = 0;
        }

        public CfQuery(long maxResult, long firstResult)
        {
            MaxResults = maxResult;
            FirstResult = firstResult;
        }
    }
}
