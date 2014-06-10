using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface ICallClient : IClient
    {
        /// <summary>
        /// Creates a call broadcast, adds numbers to it, and sends it immediately
        /// </summary>
        /// <param name="cfSendCall"></param>
        /// <returns>Unique ID of resource</returns>
        long SendCall(CfSendCall cfSendCall);

        /// <summary>
        /// Lists inbound and outbound calls
        /// </summary>
        /// <param name="cfActionQuery"></param>
        /// <returns>List of Calls</returns>
        CfCallQueryResult QueryCalls(CfActionQuery cfActionQuery);

        /// <summary>
        /// Gets a call by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <returns>Call requested</returns>
        CfCall GetCall(long id);

        /// <summary>
        /// Creates a new CallFire-hosted sound for use in calls
        /// </summary>
        /// <param name="cfCreateSound"></param>
        /// <returns>Unique ID of resource</returns>
        long CreateSound(CfCreateSound cfCreateSound);

        /// <summary>
        /// Lists sounds available for use in calls
        /// </summary>
        /// <param name="cfQuerySoundMeta"></param>
        /// <returns>List of SoundMeta</returns>
        CfSoundMetaQueryResult QuerySoundMeta(CfQuery cfQuerySoundMeta);

        /// <summary>
        /// Gets metadata for a sound for use in calls
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <returns>SoundMeta requested</returns>
        CfSoundMeta GetSoundMeta(long id);

        /// <summary>
        /// Gets binary data for a sound that's available for use in calls
        /// </summary>
        /// <param name="cfGetSoundData"></param>
        /// <returns>SoundData as application/octet-stream</returns>
        byte[] GetSoundData(CfGetSoundData cfGetSoundData);

        /// <summary>
        /// Gets the binary data for a sound recorded from a past call
        /// </summary>
        /// <param name="cfGetRecordingData"></param>
        /// <returns>Raw binary sound data</returns>
        byte[] GetRecordingData(CfGetRecordingData cfGetRecordingData);
    }
}
