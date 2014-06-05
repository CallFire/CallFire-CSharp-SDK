using System;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

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

        public Broadcast(CfBroadcast source)
        {
            if (source.Id.HasValue)
            {
                id = source.Id.Value;
                idSpecified = true;
            }
            Name = source.Name;
            if (source.Status.HasValue)
            {
                Status = EnumeratedMapper.ToSoapEnumerated<BroadcastStatus>(source.Status.ToString());
                StatusSpecified = true;
            }
            if (source.LastModified.HasValue)
            {
                LastModified = source.LastModified.Value;
                LastModifiedSpecified = true;
            }
            if (source.Type.HasValue)
            {
                Type = EnumeratedMapper.ToSoapEnumerated<BroadcastType>(source.Type.ToString());
                Item = BroadcastConfigMapper.ToBroadcastConfig(source.Item, source.Type.Value);
                TypeSpecified = true;
            }
        }
    }
}
