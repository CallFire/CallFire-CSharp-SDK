using System;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap

namespace CallFire_csharp_sdk.API.Soap
{
    public partial class VoiceBroadcastConfig
    {
        public VoiceBroadcastConfig(long identifier, DateTime created, string fromNumber,
        LocalTimeZoneRestriction localTimeZoneRestriction, BroadcastConfigRetryConfig retryConfig,
        AnsweringMachineConfig answeringMachineConfig, object item, string liveSoundTextVoice, object item1,
        string machineSoundTextVoice, object item2, string transferSoundTextVoice, string transferDigit,
        string transferNumber, object item3, string dncSoundTextVoice, string dncDigit, int maxActiveTransfers)
            : base(identifier, created, fromNumber, localTimeZoneRestriction, retryConfig)
        {
            AnsweringMachineConfig = answeringMachineConfig;
            Item = item;
            LiveSoundTextVoice = liveSoundTextVoice;
            Item1 = item1;
            MachineSoundTextVoice = machineSoundTextVoice;
            Item2 = item2;
            TransferSoundTextVoice = transferSoundTextVoice;
            TransferDigit = transferDigit;
            TransferNumber = transferNumber;
            Item3 = item3;
            DncSoundTextVoice = dncSoundTextVoice;
            DncDigit = dncDigit;
            MaxActiveTransfers = maxActiveTransfers;
        }

        public VoiceBroadcastConfig()
        {
        }
    }
}
