using System;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class BroadcastSchedule 
    {
        public BroadcastSchedule()
        {
        }
        
        public BroadcastSchedule(long identifier, DateTime startTimeOfDay, DateTime stopTimeOfDay, string timeZone, DateTime beginDate, DateTime endDate, string daysOfWeek)
        {
            id = identifier;
            StartTimeOfDay = startTimeOfDay;
            StopTimeOfDay = stopTimeOfDay;
            TimeZone = timeZone;
            BeginDate = beginDate;
            EndDate = endDate;
            DaysOfWeek = daysOfWeek;
        }
    }
}
