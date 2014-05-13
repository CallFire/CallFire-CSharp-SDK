using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateBroadcastSchedule
    {
        public string RequestId { get; set; }

        public long BroadcastId { get; set; }

        public CfBroadcastSchedule BroadcastSchedule { get; set; }
    }
}
