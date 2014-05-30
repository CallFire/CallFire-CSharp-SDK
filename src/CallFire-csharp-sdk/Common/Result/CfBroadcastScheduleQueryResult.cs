using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfBroadcastScheduleQueryResult : CfQueryResult
    {
        public CfBroadcastSchedule[] BroadcastSchedule { get; set; }

        public CfBroadcastScheduleQueryResult(long totalResults, CfBroadcastSchedule[] broadcastSchedule)
            : base(totalResults)
        {
            BroadcastSchedule = broadcastSchedule;
        }
    }
}
