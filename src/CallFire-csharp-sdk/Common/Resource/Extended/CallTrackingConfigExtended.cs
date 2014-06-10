using CallFire_csharp_sdk.Common.DataManagement;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CallTrackingConfig
    {
        public CallTrackingConfig(CfCallTrackingConfig source)
        {
            if (source.Id.HasValue)
            {
                id = source.Id.Value;
                idSpecified = true;
            }
            TransferNumber = source.TransferNumber;
            Screen = source.Screen;
            Record = source.Record;
            if (source.IntroSoundId.HasValue)
            {
                IntroSoundId = source.IntroSoundId.Value;
                IntroSoundIdSpecified = true;
            }
            if (source.WhisperSoundId.HasValue)
            {
                WhisperSoundId = source.WhisperSoundId.Value;
                WhisperSoundIdSpecified = true;
            }
        }
    }
}
