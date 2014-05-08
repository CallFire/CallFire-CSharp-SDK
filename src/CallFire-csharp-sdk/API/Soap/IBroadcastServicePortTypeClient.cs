namespace CallFire_csharp_sdk.API.Soap
{
    public interface IBroadcastServicePortTypeClient
    {
        long CreateBroadcast(BroadcastRequest createBroadcast1);
        BroadcastQueryResult QueryBroadcasts(QueryBroadcasts queryBroadcasts1);
        Broadcast GetBroadcast(IdRequest getBroadcast1);
        void UpdateBroadcast(BroadcastRequest updateBroadcast1);
        BroadcastStats GetBroadcastStats(GetBroadcastStats getBroadcastStats1);
        void ControlBroadcast(ControlBroadcast controlBroadcast1);
        long CreateContactBatch(CreateContactBatch createContactBatch1);
        ContactBatchQueryResult QueryContactBatches(QueryContactBatches queryContactBatches1);
        ContactBatch GetContactBatch(IdRequest getContactBatch1);
        void ControlContactBatch(ControlContactBatch controlContactBatch1);
        long CreateBroadcastSchedule(CreateBroadcastSchedule createBroadcastSchedule1);
        BroadcastScheduleQueryResult QueryBroadcastSchedule(QueryBroadcastSchedules queryBroadcastSchedules);
        BroadcastSchedule GetBroadcastSchedule(IdRequest getBroadcastSchedule1);
        void DeleteBroadcastSchedule(IdRequest deleteBroadcastSchedule1);
    }
}