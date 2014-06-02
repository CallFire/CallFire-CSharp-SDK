using CallFire_csharp_sdk.Common.DataManagement;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap

namespace CallFire_csharp_sdk.API.Soap
{
    public partial class LocalTimeZoneRestriction
    {
        public LocalTimeZoneRestriction()
        {
        }
        
        public LocalTimeZoneRestriction(CfLocalTimeZoneRestriction source)
        {
            if (source.BeginTime.HasValue)
            {
                BeginTime = source.BeginTime.Value;
                BeginTimeSpecified = true;
            }
            if (source.EndTime.HasValue)
            {
                EndTime = source.EndTime.Value;
                EndTimeSpecified = true;
            }
        }
    }
}
