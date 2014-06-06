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

        /// <summary>
        /// The name of your sound. This name is included in SoundMeta and shown in the web interface
        /// </summary>
        public string Name { get; set; }

        public object Item { get; set; }

        public string SoundTextVoice { get; set; }
    }
}
