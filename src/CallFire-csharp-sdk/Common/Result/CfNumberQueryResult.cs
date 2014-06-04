using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfNumberQueryResult : CfQueryResult
    {
        public CfNumberQueryResult(long totalResults, CfNumber[] number)
        {
            TotalResults = totalResults;
            Number = number;
        }

        public CfNumber[] Number { get; set; }
    }
}
