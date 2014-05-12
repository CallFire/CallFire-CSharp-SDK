using CallFire_csharp_sdk.API.Soap;
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
            return new CfBroadcast(source.id, source.Name, BroadcastStatusMapper.FromSoapBroadcastStatus(source.Status),
                source.LastModified, BroadcastTypeMapper.FromSoapBroadcastType(source.Type), broadcastConfig);
        }

        internal static Broadcast ToSoapBroadcast(CfBroadcast source)
        {
            if (source == null)
            {
                return null;
            }
            var broadcastConfig = BroadcastConfigMapper.ToBroadcastConfig(source.Item, source.Type);
            return new Broadcast(source.Id, source.Name,
                BroadcastStatusMapper.ToSoapBroadcastStatus(source.Status), source.LastModified,
                BroadcastTypeMapper.ToSoapBroadcastType(source.Type), broadcastConfig);
        }
    }
}
