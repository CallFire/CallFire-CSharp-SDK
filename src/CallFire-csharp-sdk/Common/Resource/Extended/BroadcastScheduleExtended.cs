using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class BroadcastSchedule 
    {
        public BroadcastSchedule()
        {
        }
        
        public BroadcastSchedule(CfBroadcastSchedule source)
        {
            if (source.Id.HasValue)
            {
                id = source.Id.Value;
                idSpecified = true;
            }
            StartTimeOfDay = source.StartTimeOfDay;
            StopTimeOfDay = source.StopTimeOfDay;
            TimeZone = source.TimeZone;
            if (source.BeginDate.HasValue)
            {
                BeginDate = source.BeginDate.Value;
                BeginDateSpecified = true;
            }
            if (source.EndDate.HasValue)
            {
                EndDate = source.EndDate.Value;
                EndDateSpecified = true;
            }
            DaysOfWeek = EnumeratedMapper.ToSoapEnumerated(source.DaysOfWeek);
        }
    }
}
