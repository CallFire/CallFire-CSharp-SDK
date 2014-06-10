using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfKeywordQueryResult : CfQueryResult
    {
        public CfKeywordQueryResult(long totalResults, CfKeyword[] keyword)
        {
            TotalResults = totalResults;
            Keyword = keyword;
        }

        /// <summary>
        /// List of Keywords
        /// </summary>
        public CfKeyword[] Keyword { get; set; }
    }
}
