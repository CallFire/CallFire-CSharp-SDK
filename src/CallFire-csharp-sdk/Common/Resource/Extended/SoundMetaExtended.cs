using System;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class SoundMeta
    {
        public SoundMeta(SoundStatus status, string name, DateTime created, int lengthInSeconds, long identifier)
        {
            Status = status;
            Name = name;
            Created = created;
            LengthInSeconds = lengthInSeconds;
            id = identifier;
        }

        public SoundMeta()
        {
        }
    }
}
