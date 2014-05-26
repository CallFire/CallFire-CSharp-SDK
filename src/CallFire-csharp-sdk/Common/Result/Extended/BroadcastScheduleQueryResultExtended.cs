// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class BroadcastScheduleQueryResult
    {
        public BroadcastScheduleQueryResult(long totalResults, BroadcastSchedule[] broadcastSchedule)
        {
            TotalResults = totalResults;
            BroadcastSchedule = broadcastSchedule;
        }

        public BroadcastScheduleQueryResult()
        {
        }
    }
}
