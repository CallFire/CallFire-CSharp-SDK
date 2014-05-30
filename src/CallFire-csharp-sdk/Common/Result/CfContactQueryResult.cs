using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfContactQueryResult : CfQueryResult
    {
        public CfContactQueryResult(long totalResults, CfContact[] contact)
        {
            TotalResults = totalResults;
            Contact = contact;
        }

        public CfContact[] Contact { get; set; }
    }
}
