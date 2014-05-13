using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface IBroadcastClient
    {
        long CreateBroadcast(CfBroadcast broadcast);

        CfBroadcastQueryResult QueryBroadcasts(CfQueryBroadcasts queryBroadcasts);

        CfBroadcast GetBroadcast(long id);

        void UpdateBroadcast(CfBroadcast broadcast);

        CfBroadcastStats GetBroadcastStats(long id);

        void ControlBroadcast(CfControlBroadcast controlBroadcast);

        long CreateContactBatch(CfCreateContactBatch createContactBatch);

        CfContactBatchQueryResult QueryContactBatches(CfQueryContactBatches queryContactBatches);

        CfContactBatch GetContactBatch(long id);

        void ControlContactBatch(CfControlContactBatch controlContactBatch);

        long CreateBroadcastSchedule(CfCreateBroadcastSchedule createBroadcastSchedule);

        CfBroadcastScheduleQueryResult QueryBroadcastSchedule(CfQueryBroadcastSchedule queryBroadcastSchedule);

        CfBroadcastSchedule GetBroadcastSchedule(long id);

        void DeleteBroadcastSchedule(long id);
    }
}
