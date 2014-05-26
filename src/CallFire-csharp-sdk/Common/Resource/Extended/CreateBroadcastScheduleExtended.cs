// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CreateBroadcastSchedule
    {
        public CreateBroadcastSchedule(string requestId, long broadcastId, BroadcastSchedule broadcastSchedule)
        {
            RequestId = requestId;
            BroadcastId = broadcastId;
            BroadcastSchedule = broadcastSchedule;
        }

        public CreateBroadcastSchedule()
        {
        }
    }
}
