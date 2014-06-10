using CallFire_csharp_sdk.Common.Resource;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CreateSound
    {
        public CreateSound(CfCreateSound cfCreateSound)
        {
            Name = cfCreateSound.Name;

            Item = cfCreateSound.Item.GetType() == typeof(CfCreateSoundRecordingCall) ? 
                new CreateSoundRecordingCall(((CfCreateSoundRecordingCall) cfCreateSound.Item).ToNumber) : cfCreateSound.Item;
            SoundTextVoice = cfCreateSound.SoundTextVoice;
        }
    }
}
