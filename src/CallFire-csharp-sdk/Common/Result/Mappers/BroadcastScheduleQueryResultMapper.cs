using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class BroadcastScheduleQueryResultMapper
    {
        internal static CfBroadcastScheduleQueryResult FromSoapBroadcastScheduleQueryResult(BroadcastScheduleQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var broadcastSchedule = source.BroadcastSchedule == null ? null
                                    : source.BroadcastSchedule.Select(BroadcastScheduleMapper.FromSoapBroadcastSchedule).ToArray();
            return new CfBroadcastScheduleQueryResult(source.TotalResults, broadcastSchedule);
        }

        internal static BroadcastScheduleQueryResult ToSoapBroadcastScheduleQueryResult(CfBroadcastScheduleQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var broadcastSchedule = source.BroadcastSchedule == null ? null
                                    : source.BroadcastSchedule.Select(BroadcastScheduleMapper.ToSoapBroadcastSchedule).ToArray();
            return new BroadcastScheduleQueryResult(source.TotalResults, broadcastSchedule);
        }
    }
}
