using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap

namespace CallFire_csharp_sdk.API.Soap
{
    public partial class VoiceBroadcastConfig
    {
        public VoiceBroadcastConfig()
        {
        }
        
        public VoiceBroadcastConfig(CfVoiceBroadcastConfig source)
        {
            if (source.Id.HasValue)
            {
                id = source.Id.Value;
                idSpecified = true;
            }
            if (source.Created.HasValue)
            {
                Created = source.Created.Value;
                CreatedSpecified = true;
            }
            FromNumber = source.FromNumber;
            LocalTimeZoneRestriction = LocalTimeZoneRestrictionMapper.ToSoapLocalTimeZoneRestriction(source.LocalTimeZoneRestriction);
            RetryConfig = BroadcastConfigRetryConfigMapper.ToBroadcastConfigRetryConfig(source.RetryConfig);

            if (source.AnsweringMachineConfig.HasValue)
            {
                AnsweringMachineConfig = EnumeratedMapper.ToSoapEnumerated<AnsweringMachineConfig>(source.AnsweringMachineConfig.ToString());
                AnsweringMachineConfigSpecified = true;
            }
            Item = source.Item;
            LiveSoundTextVoice = source.LiveSoundTextVoice;
            Item1 = source.Item1;
            MachineSoundTextVoice = source.MachineSoundTextVoice;
            Item2 = source.Item2;
            TransferSoundTextVoice = source.TransferSoundTextVoice;
            TransferDigit = source.TransferDigit;
            TransferNumber = source.TransferNumber;
            Item3 = source.Item3;
            DncSoundTextVoice = source.DncSoundTextVoice;
            DncDigit = source.DncDigit;
            if (source.MaxActiveTransfers.HasValue)
            {
                MaxActiveTransfers = source.MaxActiveTransfers.Value;
                MaxActiveTransfersSpecified = true;
            }
        }
    }
}
