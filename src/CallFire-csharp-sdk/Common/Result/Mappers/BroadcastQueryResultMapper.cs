using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class BroadcastQueryResultMapper
    {

        internal static CfBroadcastQueryResult FromSoapBroadcastQueryResult(BroadcastQueryResult source)
        {
            return source == null ? null :
                new CfBroadcastQueryResult(
                    source.TotalResults,
                    source.Broadcast == null ? null : source.Broadcast.Select(BroadcastMapper.FromSoapBroadCast).ToArray());
        }

        internal static BroadcastQueryResult ToSoapBroadcastQueryResult(CfBroadcastQueryResult source)
        {
            return source == null ? null :
                new BroadcastQueryResult(
                    source.TotalResults, 
                    source.Broadcast == null ? null : source.Broadcast.Select(BroadcastMapper.ToSoapBroadcast).ToArray());
        }
    }
}
