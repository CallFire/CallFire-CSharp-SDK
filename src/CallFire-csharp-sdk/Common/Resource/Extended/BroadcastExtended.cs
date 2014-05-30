using System;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap

namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Broadcast
    {
        public Broadcast()
        {
        }
        
        public Broadcast(long identifier, string name, BroadcastStatus status, DateTime lastModified, BroadcastType type, BroadcastConfig item)
        {
            id = identifier;
            Name = name;
            Status = status;
            LastModified = lastModified;
            Type = type;
            Item = item;
        }
    }
}
