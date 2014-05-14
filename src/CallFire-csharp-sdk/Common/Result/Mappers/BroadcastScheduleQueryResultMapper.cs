using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
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

            CfBroadcastSchedule[] newBroadcastScheduleArray = null;
            if (source.BroadcastSchedule != null)
            {
                var broadcastSchedule = source.BroadcastSchedule;
                newBroadcastScheduleArray = new CfBroadcastSchedule[broadcastSchedule.Count()];
                for (var i = 0; i < broadcastSchedule.Count(); i++)
                {
                    var item = broadcastSchedule[i];
                    newBroadcastScheduleArray[i] = BroadcastScheduleMapper.FromSoapBroadcastSchedule(item);
                }
            }
            return new CfBroadcastScheduleQueryResult(source.TotalResults, newBroadcastScheduleArray);
        }

        internal static BroadcastScheduleQueryResult ToSoapBroadcastScheduleQueryResult(CfBroadcastScheduleQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            BroadcastSchedule[] newBroadcastScheduleArray = null;
            if (source.BroadcastSchedule != null)
            {
                var broadcastSchedule = source.BroadcastSchedule;
                newBroadcastScheduleArray = new BroadcastSchedule[broadcastSchedule.Count()];
                for (var i = 0; i < broadcastSchedule.Count(); i++)
                {
                    var item = broadcastSchedule[i];
                    newBroadcastScheduleArray[i] = BroadcastScheduleMapper.ToSoapBroadcastSchedule(item);
                }
            }
            return new BroadcastScheduleQueryResult(source.TotalResults, newBroadcastScheduleArray);
        }
    }
}
