using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    class VoiceBroadcastConfigMapper
    {
        internal static CfVoiceBroadcastConfig FromSoapVoiceBroadcastConfig(VoiceBroadcastConfig source)
        {
            if (source == null)
            {
                return null;
            }
            var localTimeZoneRestriction =
                LocalTimeZoneRestrictionMapper.FromSoapLocalTimeZoneRestriction(source.LocalTimeZoneRestriction);
            var retryConfig = BroadcastConfigRetryConfigMapper.FromBroadcastConfigRetryConfig(source.RetryConfig);
            var answeringMachineConfig =
                AnsweringMachineConfigMapper.FromSoapAnsweringMachineConfig(source.AnsweringMachineConfig);
            return new CfVoiceBroadcastConfig(source.id, source.Created, source.FromNumber, localTimeZoneRestriction,
                retryConfig, answeringMachineConfig, source.Item, source.LiveSoundTextVoice, source.Item1,
                source.MachineSoundTextVoice, source.Item2, source.TransferSoundTextVoice, source.TransferDigit,
                source.TransferNumber, source.Item3, source.DncSoundTextVoice, source.DncDigit, source.MaxActiveTransfers);
        }
        
        internal static VoiceBroadcastConfig ToSoapVoiceBroadcastConfig(CfVoiceBroadcastConfig source)
        {
            if (source == null)
            {
                return null;
            }
            var localTimeZoneRestriction =
                LocalTimeZoneRestrictionMapper.ToSoapLocalTimeZoneRestriction(source.LocalTimeZoneRestriction);
            var retryConfig = BroadcastConfigRetryConfigMapper.ToBroadcastConfigRetryConfig(source.RetryConfig);
            var answeringMachineConfig =
                AnsweringMachineConfigMapper.ToSoapAnsweringMachineConfig(source.AnsweringMachineConfig);
            return new VoiceBroadcastConfig(source.Id, source.Created, source.FromNumber, localTimeZoneRestriction,
                retryConfig, answeringMachineConfig, source.Item, source.LiveSoundTextVoice, source.Item1,
                source.MachineSoundTextVoice, source.Item2, source.TransferSoundTextVoice, source.TransferDigit,
                source.TransferNumber, source.Item3, source.DncSoundTextVoice, source.DncDigit, source.MaxActiveTransfers);
        }
    }
}
