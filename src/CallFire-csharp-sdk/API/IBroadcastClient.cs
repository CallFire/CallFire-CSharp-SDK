using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface IBroadcastClient : IClient
    {
        /// <summary>
        /// Creates a new Broadcast
        /// </summary>
        /// <param name="createBroadcast"></param>
        /// <returns>Unique ID of resource</returns>
        long CreateBroadcast(CfBroadcastRequest createBroadcast);

        /// <summary>
        /// Lists existing Broadcasts
        /// </summary>
        /// <param name="queryBroadcasts"></param>
        /// <returns></returns>
        CfBroadcastQueryResult QueryBroadcasts(CfQueryBroadcasts queryBroadcasts);
        
        /// <summary>
        /// Gets a single Broadcast by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <returns></returns>
        CfBroadcast GetBroadcast(long id);

        /// <summary>
        /// Updates an existing Broadcast's configuration
        /// </summary>
        /// <param name="updateBroadcast"></param>
        void UpdateBroadcast(CfBroadcastRequest updateBroadcast);

        /// <summary>
        /// Gets performance and result statistics for a Broadcast
        /// </summary>
        /// <param name="getBroadcastStats"></param>
        /// <returns></returns>
        CfBroadcastStats GetBroadcastStats(CfGetBroadcastStats getBroadcastStats);

        /// <summary>
        /// Starts, Stops or Archives a Broadcast
        /// </summary>
        /// <param name="controlBroadcast"></param>
        void ControlBroadcast(CfControlBroadcast controlBroadcast);

        /// <summary>
        /// Creates a new ContactBatch
        /// </summary>
        /// <param name="createContactBatch"></param>
        /// <returns>Unique ID of resource</returns>
        long CreateContactBatch(CfCreateContactBatch createContactBatch);

        /// <summary>
        /// Lists a Broadcast's ContactBatch
        /// </summary>
        /// <param name="queryBroadcastData"></param>
        /// <returns></returns>
        CfContactBatchQueryResult QueryContactBatches(CfQueryBroadcastData queryBroadcastData);

        /// <summary>
        /// Gets a ContactBatch by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <returns></returns>
        CfContactBatch GetContactBatch(long id);

        /// <summary>
        /// Enables or Disables a Broadcast's ContactBatch
        /// </summary>
        /// <param name="controlContactBatch"></param>
        void ControlContactBatch(CfControlContactBatch controlContactBatch);

        /// <summary>
        /// Creates a new Schedule for a Broadcast
        /// </summary>
        /// <param name="createBroadcastSchedule"></param>
        /// <returns>Unique ID of resource</returns>
        long CreateBroadcastSchedule(CfCreateBroadcastSchedule createBroadcastSchedule);

        /// <summary>
        /// Lists existing BroadcastSchedules
        /// </summary>
        /// <param name="queryBroadcastData"></param>
        /// <returns></returns>
        CfBroadcastScheduleQueryResult QueryBroadcastSchedule(CfQueryBroadcastData queryBroadcastData);

        /// <summary>
        /// Gets a BroadcastSchedule by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <returns></returns>
        CfBroadcastSchedule GetBroadcastSchedule(long id);

        /// <summary>
        /// Deletes a BroadcastSchedule by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        void DeleteBroadcastSchedule(long id);
    }
}
