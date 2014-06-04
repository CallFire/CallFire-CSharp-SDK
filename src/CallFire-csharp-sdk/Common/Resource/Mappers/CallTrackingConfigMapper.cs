using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class CallTrackingConfigMapper
    {
        internal static CfCallTrackingConfig FromCallTrackingConfig(CallTrackingConfig source)
        {
            return source == null ? null : new CfCallTrackingConfig(source.id, source.TransferNumber, 
                source.Screen, source.Record, source.IntroSoundId, source.WhisperSoundId);
        }

        internal static CallTrackingConfig ToCallTrackingConfig(CfCallTrackingConfig source)
        {
            return source == null ? null : new CallTrackingConfig(source);
        }
    }
}
