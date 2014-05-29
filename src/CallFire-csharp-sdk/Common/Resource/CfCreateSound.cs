namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateSound
    {
        public CfCreateSound(string name, object item, string soundTextVoice)
        {
            Name = name;
            Item = item;
            SoundTextVoice = soundTextVoice;
        }

        public string Name { get; set; }

        public object Item { get; set; }

        public string SoundTextVoice { get; set; }
    }
}
