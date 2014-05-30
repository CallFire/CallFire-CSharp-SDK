using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BroadcastScheduleMapper
    {
        internal static CfBroadcastSchedule FromSoapBroadcastSchedule(BroadcastSchedule source)
        {
            if (source == null)
            {
                return null;
            }
            var daysOfWeek = EnumeratedMapper.ArrayFromSoapEnumerated<CfDaysOfWeek>(source.DaysOfWeek);
            return new CfBroadcastSchedule(source.id, source.StartTimeOfDay, source.StopTimeOfDay, source.TimeZone,
                source.BeginDate, source.EndDate, daysOfWeek);
        }

        internal static BroadcastSchedule ToSoapBroadcastSchedule(CfBroadcastSchedule source)
        {
            if (source == null)
            {
                return null;
            }
            var daysOfWeek = EnumeratedMapper.ToSoapEnumerated(source.DaysOfWeek);
            return new BroadcastSchedule(source.Id, source.StartTimeOfDay, source.StopTimeOfDay,
                source.TimeZone, source.BeginDate, source.EndDate, daysOfWeek);
        }
    }
}
