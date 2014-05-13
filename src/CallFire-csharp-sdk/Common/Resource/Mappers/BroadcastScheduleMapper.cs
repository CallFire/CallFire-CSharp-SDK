using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    class BroadcastScheduleMapper
    {
        internal static CfBroadcastSchedule FromSoapBroadcastSchedule(BroadcastSchedule source)
        {
            if (source == null)
            {
                return null;
            }
            return new CfBroadcastSchedule(source.id, source.StartTimeOfDay, source.StopTimeOfDay, source.TimeZone,
                source.BeginDate, source.EndDate, source.DaysOfWeek);
        }

        internal static BroadcastSchedule ToSoapBroadcastSchedule(CfBroadcastSchedule source)
        {
            if (source == null)
            {
                return null;
            }
            return new BroadcastSchedule(source.Id, source.StartTimeOfDay, source.StopTimeOfDay,
                source.TimeZone, source.BeginDate, source.EndDate, source.DaysOfWeek);
        }
    }
}
