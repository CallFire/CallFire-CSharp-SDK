using System;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ContactBatch
    {
        public ContactBatch(long identifier, string name, BatchStatus status, long broadcastId, DateTime created, int size, int remaining)
        {
            Name = name;
            Status = status;
            BroadcastId = broadcastId;
            Created = created;
            Size = size;
            Remaining = remaining;
            id = identifier;
        }
    }
}
