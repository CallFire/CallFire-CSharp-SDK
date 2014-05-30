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

        public long Id { get; set; }

        public CfSoundFormat Format { get; set; }
    }
}
