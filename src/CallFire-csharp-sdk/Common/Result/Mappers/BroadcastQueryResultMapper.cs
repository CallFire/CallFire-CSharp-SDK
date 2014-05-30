using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class BroadcastQueryResultMapper
    {

        internal static CfBroadcastQueryResult FromSoapBroadcastQueryResult(BroadcastQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var broadcast = source.Broadcast == null ? null
                            : source.Broadcast.Select(BroadcastMapper.FromSoapBroadCast).ToArray();
            return new CfBroadcastQueryResult(source.TotalResults, broadcast);
        }

        internal static BroadcastQueryResult ToSoapBroadcastQueryResult(CfBroadcastQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var broadcast = source.Broadcast == null ? null
                            : source.Broadcast.Select(BroadcastMapper.ToSoapBroadcast).ToArray();
            return new BroadcastQueryResult(source.TotalResults, broadcast);
        }
    }
}
