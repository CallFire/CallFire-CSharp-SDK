using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    class BroadcastScheduleQueryResultMapper
    {
        internal static CfBroadcastScheduleQueryResult FromSoapBroadcastScheduleQueryResult(BroadcastScheduleQueryResult source)
        {
            if (source == null)
            {
                return null;
            }
            var broadcastSchedule = source.BroadcastSchedule;
            var newBroadcastScheduleArray = new CfBroadcastSchedule[broadcastSchedule.Count()];
            for (var i = 0; i < broadcastSchedule.Count(); i++)
            {
                var item = broadcastSchedule[i];
                newBroadcastScheduleArray[i] = BroadcastScheduleMapper.FromSoapBroadcastSchedule(item);
            }
            return new CfBroadcastScheduleQueryResult(source.TotalResults, newBroadcastScheduleArray);
        }

        internal static BroadcastScheduleQueryResult ToSoapBroadcastScheduleQueryResult(CfBroadcastScheduleQueryResult source)
        {
            if (source == null)
            {
                return null;
            }
            var broadcastSchedule = source.BroadcastSchedule;
            var newBroadcastScheduleArray = new BroadcastSchedule[broadcastSchedule.Count()];
            for (var i = 0; i < broadcastSchedule.Count(); i++)
            {
                var item = broadcastSchedule[i];
                newBroadcastScheduleArray[i] = BroadcastScheduleMapper.ToSoapBroadcastSchedule(item);
            }
            return new BroadcastScheduleQueryResult(source.TotalResults, newBroadcastScheduleArray);
        }
    }
}
