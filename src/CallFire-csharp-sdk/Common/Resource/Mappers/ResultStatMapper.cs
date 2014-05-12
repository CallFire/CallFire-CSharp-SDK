using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class ResultStatMapper
    {
        internal static CfBroadcastStatsResultStat[] FromSoapBroadcastResultStat(BroadcastStatsResultStat[] source)
        {
            if (source == null)
            {
                return null;
            }
            var result = new CfBroadcastStatsResultStat[source.Count()];
            for (var i = 0; i < source.Count(); i++)
            {
                var item = source[i];
                if (item != null)
                {
                    result[i] = new CfBroadcastStatsResultStat(item.Result, item.Attempts, item.Actions);
                }
            }
            return result;
        }

        internal static BroadcastStatsResultStat[] ToSoapBroadcastResultStat(CfBroadcastStatsResultStat[] source)
        {
            if (source == null)
            {
                return null;
            }
            var result = new BroadcastStatsResultStat[source.Count()];
            for (var i = 0; i < source.Count(); i++)
            {
                var item = source[i];
                if (item != null)
                {
                    result[i] = new BroadcastStatsResultStat(item.Result, item.Attempts, item.Actions);
                }
            }
            return result;
        }
    }
}
