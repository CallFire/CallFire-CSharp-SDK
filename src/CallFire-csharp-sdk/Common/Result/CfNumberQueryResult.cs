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

        /// <summary>
        /// List of Numbers
        /// </summary>
        public CfNumber[] Number { get; set; }
    }
}
