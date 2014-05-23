using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class BroadcastScheduleQueryResultMapper
    {
        internal static CfBroadcastScheduleQueryResult FromSoapBroadcastScheduleQueryResult(BroadcastScheduleQueryResult source)
        {
            return source == null ? null :
                new CfBroadcastScheduleQueryResult(
                    source.TotalResults,
                    source.BroadcastSchedule == null ? null : source.BroadcastSchedule.Select(BroadcastScheduleMapper.FromSoapBroadcastSchedule).ToArray());
        }

        internal static BroadcastScheduleQueryResult ToSoapBroadcastScheduleQueryResult(CfBroadcastScheduleQueryResult source)
        {
            return source == null ? null :
                new BroadcastScheduleQueryResult(
                    source.TotalResults,
                    source.BroadcastSchedule == null ? null : source.BroadcastSchedule.Select(BroadcastScheduleMapper.ToSoapBroadcastSchedule).ToArray());
        }
    }
}
