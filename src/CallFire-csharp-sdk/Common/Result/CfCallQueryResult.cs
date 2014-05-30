using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfCallQueryResult : CfQueryResult
    {
        public CfCallQueryResult(long totalResults, CfCall[] calls)
            : base(totalResults)
        {
            TotalResults = totalResults;
            Calls = calls;
        }

        public CfCall[] Calls { get; set; }
    }
}
