using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfTextQueryResult : CfQueryResult
    {
        public CfTextQueryResult(long totalResults, CfText[] text)
        {
            TotalResults = totalResults;
            Text = text;
        }

        /// <summary>
        /// List of Texts 
        /// </summary>
        public CfText[] Text { get; set; }
    }
}
