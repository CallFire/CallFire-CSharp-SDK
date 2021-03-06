﻿using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BroadcastMapper
    {
        internal static CfBroadcast FromSoapBroadCast(Broadcast source)
        {
            if (source == null)
            {
                return null;
            }
            var broadcastConfig = BroadcastConfigMapper.FromBroadcastConfig(source.Item, source.Type);
            return new CfBroadcast(source.id, source.Name, EnumeratedMapper.EnumFromSoapEnumerated<CfBroadcastStatus>(source.Status.ToString()),
                source.LastModified, EnumeratedMapper.EnumFromSoapEnumerated<CfBroadcastType>(source.Type.ToString()), broadcastConfig);
        }

        internal static Broadcast ToSoapBroadcast(CfBroadcast source)
        {
            return source == null ? null : new Broadcast(source);
        }
    }
}
