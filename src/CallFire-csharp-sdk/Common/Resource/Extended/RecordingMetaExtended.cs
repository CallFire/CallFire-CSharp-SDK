using System;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class RecordingMeta
    {
        public RecordingMeta()
        {
        }
        
        public RecordingMeta(string name, DateTime created, int lengthInSeconds, string link, long identifier)
        {
            Name = name;
            Created = created;
            LengthInSeconds = lengthInSeconds;
            Link = link;
            id = identifier;
        }
    }
}
