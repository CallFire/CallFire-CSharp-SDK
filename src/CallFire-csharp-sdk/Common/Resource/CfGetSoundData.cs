using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfGetSoundData
    {
        public CfGetSoundData(long id, CfSoundFormat format)
        {
            Id = id;
            Format = format;
        }

        /// <summary>
        /// Unique ID of resource
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Specifies the format of the returned sound data [Wav, Mp3]
        /// </summary>
        public CfSoundFormat Format { get; set; }
    }
}
