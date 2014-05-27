using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfLabelQueryResult : CfQueryResult
    {
        public CfLabel[] Labels { get; set; }

        public CfLabelQueryResult(long totalResults, CfLabel[] labels)
        {
            TotalResults = totalResults;
            Labels = labels;
        }
    }
}
