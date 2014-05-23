using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface IBroadcastClient : IClient
    {
        long CreateBroadcast(CfBroadcastRequest createBroadcast);

        CfBroadcastQueryResult QueryBroadcasts(CfQueryBroadcasts queryBroadcasts);
        
        CfBroadcast GetBroadcast(long id);

        void UpdateBroadcast(CfBroadcastRequest updateBroadcast);

        CfBroadcastStats GetBroadcastStats(CfGetBroadcastStats getBroadcastStats);

        void ControlBroadcast(CfControlBroadcast controlBroadcast);

        long CreateContactBatch(CfCreateContactBatch createContactBatch);

        CfContactBatchQueryResult QueryContactBatches(CfQueryBroadcastData queryBroadcastData);

        CfContactBatch GetContactBatch(long id);

        void ControlContactBatch(CfControlContactBatch controlContactBatch);

        long CreateBroadcastSchedule(CfCreateBroadcastSchedule createBroadcastSchedule);

        CfBroadcastScheduleQueryResult QueryBroadcastSchedule(CfQueryBroadcastData queryBroadcastSchedule);

        CfBroadcastSchedule GetBroadcastSchedule(long id);

        void DeleteBroadcastSchedule(long id);
    }
}
