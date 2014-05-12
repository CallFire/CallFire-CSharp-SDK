// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class BroadcastStatsActionStatistics
    {
        public BroadcastStatsActionStatistics(int unattempted, int retryWait, int finished)
        {
            Unattempted = unattempted;
            RetryWait = retryWait;
            Finished = finished;
        }
    }
}
