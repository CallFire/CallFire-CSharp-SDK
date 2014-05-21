// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class BroadcastQueryResult
    {
        public BroadcastQueryResult(long totalResults, Broadcast[] broadcasts)
        {
            TotalResults = totalResults;
            Broadcast = broadcasts;
        }

        public BroadcastQueryResult()
        {
        }
    }
}
