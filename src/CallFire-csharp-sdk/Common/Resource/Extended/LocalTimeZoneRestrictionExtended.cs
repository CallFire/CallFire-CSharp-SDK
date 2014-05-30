using System;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap

namespace CallFire_csharp_sdk.API.Soap
{
    public partial class LocalTimeZoneRestriction
    {
        public LocalTimeZoneRestriction()
        {
        }
        
        public LocalTimeZoneRestriction(DateTime beginTime, DateTime endTime)
        {
            BeginTime = beginTime;
            EndTime = endTime;
        }
    }
}
