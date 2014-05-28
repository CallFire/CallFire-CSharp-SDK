namespace CallFire_csharp_sdk.Common.Result
{
    public class CfQueryResult
    {
        public CfQueryResult(long totalResults)
        {
            TotalResults = totalResults;
        }
        
        public CfQueryResult()
        {
        }

        public long TotalResults { get; set; }
    }
}
