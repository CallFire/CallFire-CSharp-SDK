namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQuery
    {
        /// <summary>
        /// Max number of results to return limited to 1000 (default: 1000)
        /// </summary>
        public long MaxResults { get; set; }

        /// <summary>
        /// Start of next result set (default: 0)
        /// </summary>
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
