using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
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

            CfBroadcast[] newBroadcastArray = null;
            if (source.Broadcast != null)
            {
                var broadcast = source.Broadcast;
                newBroadcastArray = new CfBroadcast[broadcast.Count()];
                for (var i = 0; i < broadcast.Count(); i++)
                {
                    var item = broadcast[i];
                    newBroadcastArray[i] = BroadcastMapper.FromSoapBroadCast(item);
                }
            }
            return new CfBroadcastQueryResult(source.TotalResults, newBroadcastArray);
        }

        internal static BroadcastQueryResult ToSoapBroadcastQueryResult(CfBroadcastQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            Broadcast[] newBroadcastArray = null;
            if (source.Broadcast != null)
            {
                var broadcast = source.Broadcast;
                newBroadcastArray = new Broadcast[broadcast.Count()];
                for (var i = 0; i < broadcast.Count(); i++)
                {
                    var item = broadcast[i];
                    newBroadcastArray[i] = BroadcastMapper.ToSoapBroadcast(item);
                }
            }
            return new BroadcastQueryResult(source.TotalResults, newBroadcastArray);
        }
    }
}
