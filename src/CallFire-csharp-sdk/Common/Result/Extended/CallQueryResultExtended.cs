// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CallQueryResult
    {
        public CallQueryResult()
        {
        }
        
        public CallQueryResult(long totalResults, Call[] call)
        {
            TotalResults = totalResults;
            Call = call;
        }
    }
}
