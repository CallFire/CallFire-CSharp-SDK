using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfLabelQueryResult : CfQueryResult
    {
        /// <summary>
        /// List of Labels
        /// </summary>
        public CfLabel[] Labels { get; set; }

        public CfLabelQueryResult(long totalResults, CfLabel[] labels)
        {
            TotalResults = totalResults;
            Labels = labels;
        }
    }
}
