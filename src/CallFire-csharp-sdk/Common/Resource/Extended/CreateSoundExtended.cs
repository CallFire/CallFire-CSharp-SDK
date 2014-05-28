// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CreateSound
    {
        public CreateSound(string name, object item, string soundTextVoice)
        {
            Name = name;
            Item = item;
            SoundTextVoice = soundTextVoice;
        }
    }
}
